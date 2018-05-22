

namespace NCD.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Mail;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using RazorEngine.Templating;
    using iTextSharp.text.html.simpleparser;
    using NCD.Infrastructure.Helpers;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    using NDC.Infrastructure.Models;

    public sealed class EmailSender
    {
        /// <summary>
        /// E-mail partion size
        /// </summary>
        private const int ATTACHMENT_SIZE = 10;

        /// <summary>
        /// Send async email 
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="people"></param>
        /// <returns></returns>
        public async Task BatchSendAsync(string destination, Person[] people)
        { 
            //destination
            if (string.IsNullOrWhiteSpace(destination))
                throw new ArgumentNullException("destination");

            //check people
            if (people == null || !people.Any())
                throw new ArgumentNullException("people");

            //template path
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Templates\EmailTemplate.cshtml");

            // Partition the entire source array.
            //https://msdn.microsoft.com/en-us/library/dd997411(v=vs.110).aspx
            var rangePartitioner = Partitioner.Create(0, people.Length, ATTACHMENT_SIZE);

            // Loop over the partitions
            var rangePartitions = rangePartitioner.GetDynamicPartitions();

            foreach (var rangePartition in rangePartitions)
            {
                var attachments = new string[rangePartition.Item2 - rangePartition.Item1];
                var attachmentIndex = 0;

                // Loop over each range element without a delegate invocation.
                for (var counter = rangePartition.Item1; counter < rangePartition.Item2; counter++)
                {
                    var person = people[counter];
                    var html = RazorHelper.Compile(path, person);
                    var pdf = iTextSharpHelper.Convert(html);
                    var tmpPath = Path.Combine(Path.GetTempPath(), String.Format("{0}_{1}.pdf", person.FullName, Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));

                    File.WriteAllBytes(tmpPath, pdf);

                    attachments[attachmentIndex] = tmpPath;
                    attachmentIndex++;
                }

                var subject = string.Format("Criminal Profiles - Part {0}/{1}", rangePartition.Item1 + 1, rangePartition.Item2);
                var body = @"Hi, we are sending you the results of your search. Please open the attached files.";

                await SendGridHelper.SendAsync(destination, subject, body, attachments);
            }

        }


    }
}

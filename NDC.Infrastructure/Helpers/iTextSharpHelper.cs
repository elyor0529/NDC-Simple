
namespace NCD.Infrastructure.Helpers
{
    using iTextSharp.text;
    using iTextSharp.text.html.simpleparser;
    using iTextSharp.text.pdf;
    using System;
    using System.IO;

    public static class iTextSharpHelper
    {
        /// <summary>
        /// iTextSharp - HTML code to Pdf data 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static byte[] Convert(string content)
        {
            //check if has html code
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentNullException("content");

            //buffer
            using (var ms = new MemoryStream())
            {
                //doc
                using (var doc = new Document())
                {
                    //writer
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        //open
                        doc.Open();

                        //html parser
                        using (var htmlWorker = new HTMLWorker(doc))
                        {
                            //read content
                            using (var sr = new StringReader(content))
                            {
                                // to parse
                                htmlWorker.Parse(sr);
                            }
                        }

                        //close
                        doc.Close();
                    }
                }

                return ms.ToArray();
            }
        }
    }
}


namespace NCD.Infrastructure.Helpers
{
    using SendGrid;
    using System.Configuration;
    using System.IO;
    using System.Net.Mail;
    using System.Threading.Tasks;

    public static class SendGridHelper
    {
        /// <summary>
        /// SendGrid send sync email
        /// https://sendgrid.com/docs/Integrate/Code_Examples/csharp.html
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="attachments"></param>
        /// <returns></returns>
        public static async Task SendAsync(string destination, string subject, string body, params string[] attachments)
        {
            var message = new SendGridMessage();
            var from = ConfigurationManager.AppSettings["AdminEmail"];

            message.AddTo(destination);
            message.From = new MailAddress(from);
            message.Subject = subject;

            //by default sended text format
            message.Text = body;

            //if set for this property , sended HTML format
            message.Html = body;

            // by default this enabled,after them faster sended no tracked at SendGrid server
            message.DisableClickTracking();

            //check attachments
            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    // add to pysical file path
                    message.AddAttachment(attachment);
                }
            }

            // Create a Web transport for sending email. 
            var transportWeb = new Web(ConfigurationManager.AppSettings["SendGridKey"]);

            // Send the email.
            if (transportWeb != null)
            {
                await transportWeb.DeliverAsync(message);

                //after delivered we to need delete recently files
                foreach (var attachment in attachments)
                {
                    //delete tmp file
                    File.Delete(attachment);
                }
            }
            else
            {
                //if get any exception
                await Task.FromResult(0);
            }
        }
    }
}

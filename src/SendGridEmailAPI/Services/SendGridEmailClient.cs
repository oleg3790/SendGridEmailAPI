using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SendGridEmailAPI.Services
{
    public class SendGridEmailClient : IEmailSendClient
    {
        private readonly string _apiKey;

        public SendGridEmailClient(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<HttpStatusCode> SendEmailAsync(string fromEmail, string fromEmailName, string toEmail, string subject, string message)
        {
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.AddTo(toEmail);
            sendGridMessage.From = new EmailAddress(fromEmail, fromEmailName);
            sendGridMessage.Subject = subject;
            sendGridMessage.HtmlContent = message;

            SendGrid.ISendGridClient transportWeb = new SendGrid.SendGridClient(_apiKey);
            SendGrid.Response emailTask = await transportWeb.SendEmailAsync(sendGridMessage);

            return emailTask.StatusCode;
        }
    }
}

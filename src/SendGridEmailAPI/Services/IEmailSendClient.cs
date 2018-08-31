using System.Net;
using System.Threading.Tasks;

namespace SendGridEmailAPI.Services
{
    public interface IEmailSendClient
    {
        Task<HttpStatusCode> SendEmailAsync(string fromEmail, string fromEmailName, string toEmail, string subject, string message);
    }
}

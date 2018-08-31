using System.Threading.Tasks;

namespace SendGridEmailAPI.Services
{
    public interface IEmailSendClient
    {
        Task SendEmailAsync(string fromEmail, string fromEmailName, string toEmail, string subject, string message);
    }
}

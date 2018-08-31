using Microsoft.AspNetCore.Mvc;
using SendGridEmailAPI.Model;
using SendGridEmailAPI.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SendGridEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSendClient _emailSender;

        public EmailController(IEmailSendClient emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpGet]
        public string Get()
        {
            return string.Format("The following are keys to include in POST to server: {0}",
                typeof(EmailRequest).GetProperties()
                .Select(x => x.Name)
                .ToList()
                .Aggregate((x, y) => string.Format("{0}, {1}", x, y)));
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(
                    ModelState.Values.Select(
                        x => x.Errors.Select(
                            y => new { error = y.ErrorMessage })));
            }

            try
            {
                await _emailSender.SendEmailAsync(
                    request.FromEmail, 
                    request.FromEmailName, 
                    request.ToEmail, 
                    request.EmailSubject,
                    request.EmailMessage);

                return new JsonResult(new { result = "success" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message });
            }
        }
    }
}

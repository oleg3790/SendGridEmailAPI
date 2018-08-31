using Microsoft.AspNetCore.Mvc;
using SendGridEmailAPI.Services;

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

        // Test method
        [HttpGet]
        public string Get()
        {
            return "Success";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}

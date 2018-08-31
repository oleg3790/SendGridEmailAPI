using Microsoft.AspNetCore.Mvc;

namespace SendGridEmailAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
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

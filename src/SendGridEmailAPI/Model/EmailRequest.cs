using System.ComponentModel.DataAnnotations;

namespace SendGridEmailAPI.Model
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string FromEmail { get; set; }

        [MaxLength(50)]
        public string FromEmailName { get; set; }

        [EmailAddress]
        [Required]
        public string ToEmail { get; set; }

        [Required]
        public string EmailSubject { get; set; }

        [Required]
        public string EmailMessage { get; set; }
    }
}

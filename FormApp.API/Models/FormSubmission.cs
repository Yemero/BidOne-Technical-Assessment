using System.ComponentModel.DataAnnotations;

namespace FormApp.API.Models
{
    public class FormSubmission
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
using System.ComponentModel.DataAnnotations;

namespace FormApp.API.Models
{
    public class FormSubmission
    {
        [Required( ErrorMessage = "First name is required" )]
        public string FirstName { get; set; } = string.Empty;
        [Required( ErrorMessage = "Last name is required" )]
        public string LastName { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
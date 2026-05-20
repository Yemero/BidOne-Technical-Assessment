using Microsoft.AspNetCore.Mvc;
using FormApp.API.Models;
using FormApp.API.Services;

namespace FormApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        // Inject the JsonFileService to handle file operations
        private readonly JsonFileService _fileService;

        public FormController(JsonFileService fileService)
        {
            _fileService = fileService;
        }
        
        [HttpPost]
        public IActionResult Submit([FromBody] FormSubmission submission)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _fileService.Save(submission);

            return Ok(new { message = "Submission saved successfully." });
        }
    }
}
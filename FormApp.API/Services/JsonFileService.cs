using System.Text.Json;
using FormApp.API.Models;

namespace FormApp.API.Services
{
    public class JsonFileService
    {
        private readonly string _filePath = "submissions.json";

        public void Save(FormSubmission submission)
        {
            var submissions = new List<FormSubmission>();

            if (File.Exists(_filePath))
            {
                var existingJson = File.ReadAllText(_filePath);
                submissions = JsonSerializer.Deserialize<List<FormSubmission>>(existingJson)
                              ?? new List<FormSubmission>();
            }

            submissions.Add(submission);

            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_filePath, JsonSerializer.Serialize(submissions, options));
        }
    }
}
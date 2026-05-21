using System.Text.Json;
using FormApp.API.Models;

namespace FormApp.API.Services
{
    public class JsonFileService
    {
        private readonly string _filePath = "submissions.json";

        /// Appends a new submission to the JSON file.
        /// Creates the file if it does not already exist.
        public void Save(FormSubmission submission)
        {
            var submissions = LoadExisting();
            submissions.Add(submission);
            WriteToFile(submissions);
        }

        // Reads and deserializes existing submissions from the file.
        // Returns an empty list if the file does not exist.
        private List<FormSubmission> LoadExisting()
        {
            if (!File.Exists(_filePath))
                return new List<FormSubmission>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<FormSubmission>>(json)
                   ?? new List<FormSubmission>();
        }

        // Serializes the full submissions list and writes it to the file.
        private void WriteToFile(List<FormSubmission> submissions)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(_filePath, JsonSerializer.Serialize(submissions, options));
        }
    }
}
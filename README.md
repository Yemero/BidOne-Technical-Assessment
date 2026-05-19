# Form Submission App (MVC version)
A simple web application built as a technical assessment. A form collects a first name and last name, submits the data to a backend, and each submission is saved as an object to a local JSON file.
 
This repository contains **two implementations** available as separate branches:
 
| Branch | Approach |
|--------|---------|
| `main` | [Angular frontend + ASP.NET Core Web API](https://github.com/Yemero/BidOne-Technical-Assessment) |
| `mvc-version` | [Single ASP.NET Core MVC application]() |

### Tech Stack
 
| Layer | Technology |
|-------|-----------|
| Frontend | Razor Views (.cshtml) |
| Backend | ASP.NET Core MVC (.NET 8) |
| Data Storage | Local JSON file |
 
### Project Structure
 
```
FormApp/
└── FormApp.MVC/
    ├── Controllers/
    │   └── HomeController.cs
    ├── Models/
    │   └── FormSubmission.cs
    ├── Services/
    │   └── JsonFileService.cs
    ├── Views/
    │   └── Home/
    │       ├── Index.cshtml
    │       └── Success.cshtml
    └── Program.cs
```
 
### Prerequisites
 
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
### How to Run
 
Only one terminal needed:
 
```bash
cd FormApp.MVC
dotnet run
```
 
Open your browser and go to `http://localhost:5000`.
 
### How It Works
 
1. The user visits `http://localhost:5000` — the server renders the form via Razor
2. The user fills in **First Name** and **Last Name** and submits
3. The browser POSTs the form data to the `HomeController`
4. The controller validates the model via data annotations
5. The submission is saved to `FormApp.MVC/submissions.json`
6. The user is redirected to a success page
---
 
## Example JSON Output
 
After a successful submission, `submissions.json` will look like this:
 
```json
[
  {
    "firstName": "Jane",
    "lastName": "Doe",
    "submittedAt": "2025-01-01T00:00:00Z"
  },
  {
    "firstName": "John",
    "lastName": "Smith",
    "submittedAt": "2025-01-01T00:01:00Z"
  }
]
```
 
Each submission is appended to the array. The file is created automatically on the first submission.
 


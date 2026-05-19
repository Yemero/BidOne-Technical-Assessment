# Form Submission App
A simple web application built as a technical assessment. A form on the Angular frontend collects a first name and last name, posts the data to an ASP.NET Core Web API, and the backend saves each submission as an object to a local JSON file.

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Frontend | Angular 19 |
| Backend | ASP.NET Core Web API (.NET 8) |
| Data Storage | Local JSON file |

---

## Project Structure

```
FormApp/
├── FormApp.API/              # ASP.NET Core Web API
│   ├── Controllers/
│   │   └── FormController.cs
│   ├── Models/
│   │   └── FormSubmission.cs
│   ├── Services/
│   │   └── JsonFileService.cs
│   └── Program.cs
│
└── form-app-client/          # Angular frontend
    └── src/
        └── app/
            ├── app.ts
            ├── app.html
            ├── app.config.ts
            └── form.service.ts
```

---

## Prerequisites

Make sure the following are installed before running the project:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js LTS](https://nodejs.org)
- Angular CLI — install with `npm install -g @angular/cli`

---

## How to Run

Both the API and the Angular app need to run at the same time in **separate terminals**.

### Terminal 1 — Start the API

```bash
cd FormApp.API
dotnet run
```

The API will start on `http://localhost:5000`. You should see output like:

```
Now listening on: http://localhost:5000
```

### Terminal 2 — Start the Angular App

```bash
cd form-app-client
ng serve
```

Then open your browser and go to:

```
http://localhost:4200
```

---

## How It Works

1. The user fills in their **First Name** and **Last Name** in the form
2. On submit, Angular POSTs the data to `http://localhost:5000/api/form`
3. The API receives the data as a `FormSubmission` object
4. The object is appended to `FormApp.API/submissions.json`
5. A success message is returned and displayed on the page

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

---

## API Reference

### POST `/api/form`

Accepts a form submission and saves it to the JSON file.

**Request body:**
```json
{
  "firstName": "Jane",
  "lastName": "Doe"
}
```

**Success response — 200 OK:**
```json
{
  "message": "Submission saved successfully."
}
```

**Validation failure — 400 Bad Request:**
```json
{
  "errors": {
    "FirstName": ["The FirstName field is required."]
  }
}
```
# Form Submission App
- Simple Angular frontend form that collects First Name and Last Name.
- Form data is posted to an ASP.NET Core Web API backend.
- Each submission is received as an object and saved to a local JSON file.

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Frontend | Angular 19 |
| Backend | ASP.NET Core Web API (.NET 8) |
| Data Storage | Local JSON file at `FormApp.API/submissions.json` |

---

## Prerequisites

Make sure the following are installed before running the project:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js LTS](https://nodejs.org)
- Angular CLI — install with `npm install -g @angular/cli`

---

## How to Run

Both the API and the Angular app are required to run at the same time in **separate terminals**.

### Terminal 1 — Start API

```bash
cd FormApp.API
dotnet restore
dotnet run
```

### Terminal 2 — Start Frontend
```bash
cd form-app-client
npm install
ng serve -o
```
Open your browser at `http://localhost:4200`

API runs at `http://localhost:5251`

---

## How It Works

1. The user fills in their **First Name** and **Last Name** in the form
2. On submit, Angular POSTs the data to `http://localhost:5251/api/form`
3. The API receives the data as a `FormSubmission` object
4. The object is appended to `FormApp.API/submissions.json`
5. A success message is returned and displayed on the page

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
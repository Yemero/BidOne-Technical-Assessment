# Form Submission App
A simple web application built as a technical assessment. A form on the Angular frontend collects a first name and last name, posts the data to an ASP.NET Core Web API, and the backend saves each submission as an object to a local JSON file.

| Branch | Approach |
|--------|---------|
| `main` | [Angular frontend + ASP.NET Core Web API](https://github.com/Yemero/BidOne-Technical-Assessment) |
| `mvc-version` | [Single ASP.NET Core MVC application](https://github.com/Yemero/BidOne-Technical-Assessment/tree/MVC-ver) |


---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Frontend | Angular 19 |
| Backend | ASP.NET Core Web API (.NET 8) |
| Data Storage | Local JSON file at `FormApp.API/Submissions.JSON`|

---

## Prerequisites

Make sure the following are installed before running the project:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js LTS](https://nodejs.org)
- Angular CLI — install with `npm install -g @angular/cli`

---

## How to Run

Both the API and the Angular app need to run at the same time in **separate terminals**.

### Terminal 1 — Start API

```bash
cd FormApp.API
dotnet run
```

### Terminal 2 — Start Frontend 

```bash
cd form-app-client
ng serve
```

Frontend is opened at:

```
http://localhost:4200
```

API is configured for:
```
http://localhost:5251
```

---

## How It Works

1. The user fills in their **First Name** and **Last Name** in the form
2. On submit, Angular POSTs the data to `http://localhost:5000/api/form`
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
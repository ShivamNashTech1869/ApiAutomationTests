# 🧪 API Automation Tests

> ✅ C# API Automation Framework using SpecFlow, RestSharp, and FluentAssertions

## 📌 Technologies Used

- ✅ C# .NET 7
- ✅ SpecFlow for BDD
- ✅ RestSharp for API calls
- ✅ FluentAssertions for validations
- ✅ GitHub Actions for CI
- ✅ NUnit test runner

---

## 🏗 Project Structure

ApiAutomationTests/

├

  ├── Features/ # Gherkin feature files

  ├── StepDefinitions/ # SpecFlow step bindings

  ├── Helpers/ # ApiClient and utility classes

  ├── Hooks/ # Hooks.cs
 
  ├── Models/ # UserResoonse.cs

  ├── ApiAutomationTests.csproj

├── .github/workflows/ # CI/CD workflow

└── README.md


## 🚀 Getting Started

### Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/)
- [SpecFlow](https://specflow.org/)
- [RestSharp](https://restsharp.dev/)
- [FluentAssertions](https://fluentassertions.com/)
- [Newtonsoft.Json](https://www.newtonsoft.com/json)

### Setup

```bash
git clone https://github.com/your-username/api-automation-tests.git
cd api-automation-tests
dotnet restore
```

## 🚀 Run Locally

```bash
dotnet restore
dotnet build
dotnet test
```
## 🔄 GitHub Actions CI/CD

CI pipeline is configured via .github/workflows/api-tests.yml. It automatically:

-    Installs dependencies
-    Restores and builds the project
-    Executes API tests
-    Reports results in GitHub

You can trigger the workflow on **push** or **pull_request**.

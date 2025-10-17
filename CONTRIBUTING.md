# Contributing to SepaWriter

Thank you for considering contributing to SepaWriter!

## Development Setup

### Prerequisites
- .NET 8.0 SDK or later
- A code editor (Visual Studio, Visual Studio Code, Rider, etc.)

### Building the Project
```bash
dotnet restore
dotnet build
```

### Running Tests
```bash
dotnet test
```

### Creating a NuGet Package
```bash
dotnet pack SepaWriter/SepaWriter.csproj --configuration Release --output ./artifacts
```

## Code Style
- Follow standard C# coding conventions
- Ensure all tests pass before submitting a pull request
- Add tests for any new functionality

## Submitting Changes
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin feature/my-new-feature`)
5. Create a new Pull Request

## Reporting Issues
Please use the GitHub issue tracker to report bugs or request features.

## License
By contributing to SepaWriter, you agree that your contributions will be licensed under the Apache License 2.0.

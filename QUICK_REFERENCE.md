# Quick Reference Guide

## Common Commands

### Development
```bash
# Restore dependencies
dotnet restore

# Build the project (Debug)
dotnet build

# Build the project (Release)
dotnet build --configuration Release

# Run tests
dotnet test

# Run tests with detailed output
dotnet test --verbosity detailed

# Clean build artifacts
dotnet clean
```

### NuGet Package

```bash
# Create package
dotnet pack SepaWriter/SepaWriter.csproj --configuration Release --output ./artifacts

# Create package with specific version
dotnet pack SepaWriter/SepaWriter.csproj --configuration Release --output ./artifacts /p:Version=X.Y.Z

# Publish to NuGet.org (use environment variable for security)
dotnet nuget push ./artifacts/Perrich.SepaWriter.2.0.0.nupkg --api-key $NUGET_API_KEY --source https://api.nuget.org/v3/index.json

# Publish to local feed
dotnet nuget push ./artifacts/Perrich.SepaWriter.2.0.0.nupkg --source ~/my-local-feed
```

### Testing Specific Projects

```bash
# Test only the main test project
dotnet test SepaWriter.Test/SepaWriter.Test.csproj

# Run specific test
dotnet test --filter "FullyQualifiedName~SepaCreditTransferTest"

# Generate code coverage (requires coverlet)
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

### Git Workflow

```bash
# Create feature branch
git checkout -b feature/my-feature

# Commit changes
git add .
git commit -m "Description of changes"

# Push to remote
git push origin feature/my-feature

# Create PR via GitHub UI
```

## Project Structure

```
sepawriter/
├── .github/
│   └── workflows/          # GitHub Actions CI/CD
│       ├── build.yml       # Build and test workflow
│       └── publish.yml     # NuGet publish workflow
├── Documentation/          # Additional documentation
├── SepaWriter/            # Main library project
│   ├── *.cs               # Source files
│   ├── Xsd/               # XSD schema files
│   └── SepaWriter.csproj  # Project file
├── SepaWriter.Test/       # Test project
│   ├── *.cs               # Test files
│   └── SepaWriter.Test.csproj
├── CONTRIBUTING.md        # Contributor guidelines
├── README.md             # Main documentation
└── LICENSE               # Apache 2.0 license
```

## Environment Setup

### Required
- .NET 8.0 SDK or later

### Recommended
- Visual Studio 2022+ / VS Code / Rider
- Git for version control

### Optional
- Docker (for containerized builds)
- SonarQube (for code analysis)

## Troubleshooting

### Build fails with missing SDK
```bash
# Check installed SDKs
dotnet --list-sdks

# Install .NET 8.0 SDK from:
# https://dotnet.microsoft.com/download/dotnet/8.0
```

### Test failures
```bash
# Clean and rebuild
dotnet clean
dotnet build
dotnet test

# Run tests with detailed logging
dotnet test --logger "console;verbosity=detailed"
```

### Package already exists on NuGet
```bash
# Use --skip-duplicate flag when pushing
dotnet nuget push ./artifacts/*.nupkg --api-key $NUGET_API_KEY --skip-duplicate --source https://api.nuget.org/v3/index.json

# Note: Store your API key in an environment variable for security
# export NUGET_API_KEY="your-api-key-here"
```

## Useful Links

- [.NET 8 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- [NuGet Package Publishing](https://learn.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli)
- [GitHub Actions Documentation](https://docs.github.com/en/actions)
- [ISO 20022 Standard](https://www.iso20022.org/)
- [SEPA Documentation](https://www.europeanpaymentscouncil.eu/what-we-do/sepa-credit-transfer)

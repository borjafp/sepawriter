# Building and Publishing SepaWriter

## Building the Project

### Build for Development
```bash
dotnet build
```

### Build for Release
```bash
dotnet build --configuration Release
```

## Running Tests
```bash
dotnet test
```

## Creating NuGet Package

### Local Package Creation
```bash
dotnet pack SepaWriter/SepaWriter.csproj --configuration Release --output ./artifacts
```

This will create:
- `Perrich.SepaWriter.{version}.nupkg` - The main package
- `Perrich.SepaWriter.{version}.snupkg` - Symbol package for debugging

### Package Contents
The package includes:
- `lib/net8.0/` - .NET 8.0 assemblies
- `lib/net6.0/` - .NET 6.0 assemblies
- `lib/netstandard2.0/` - .NET Standard 2.0 assemblies (for backward compatibility)
- `README.md` - Package documentation

## Publishing to NuGet.org

### Prerequisites
1. Create an account at https://www.nuget.org
2. Generate an API key from your account settings
3. Add the API key as a GitHub secret named `NUGET_API_KEY`

### Manual Publishing
```bash
dotnet nuget push ./artifacts/Perrich.SepaWriter.{version}.nupkg \
  --api-key YOUR_API_KEY \
  --source https://api.nuget.org/v3/index.json
```

### Automated Publishing via GitHub Actions
The project includes two GitHub Actions workflows:

#### Build and Test (Continuous Integration)
- Triggers on push/PR to main branches
- Builds and tests the code
- Located in `.github/workflows/build.yml`

#### Publish Package (Continuous Deployment)
- Triggers on GitHub release creation
- Can also be manually triggered
- Builds, tests, packs, and publishes to NuGet.org
- Located in `.github/workflows/publish.yml`

To publish a new version:
1. Update the version in `SepaWriter/SepaWriter.csproj`
2. Create a new GitHub release with a tag (e.g., `v2.0.0`)
3. The workflow will automatically build and publish the package

## Version Management

The package version is managed in `SepaWriter/SepaWriter.csproj`:
```xml
<PropertyGroup>
  <Version>2.0.0</Version>
</PropertyGroup>
```

Follow [Semantic Versioning](https://semver.org/):
- MAJOR version for incompatible API changes
- MINOR version for backward-compatible functionality additions
- PATCH version for backward-compatible bug fixes

## Target Frameworks

The library targets:
- `.NET 8.0` - Latest LTS version
- `.NET 6.0` - Previous LTS version
- `.NET Standard 2.0` - For broad compatibility with older frameworks

## Dependencies

### Runtime Dependencies
- `log4net` (3.0.1) - Logging framework
- `System.Text.Encoding.CodePages` (8.0.0) - Code page encoding support

### Test Dependencies
- `NUnit` (4.2.2) - Unit testing framework
- `NUnit3TestAdapter` (4.6.0) - Test adapter for Visual Studio
- `Microsoft.NET.Test.Sdk` (17.11.1) - Testing SDK

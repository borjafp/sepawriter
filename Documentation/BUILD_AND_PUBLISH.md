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
To create a package locally with a specific version:
```bash
dotnet pack SepaWriter/SepaWriter.csproj --configuration Release --output ./artifacts /p:Version=1.2.3
```

To create a package with the default version from the project file:
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
- Can also be manually triggered with a custom version
- Builds, tests, packs, and publishes to NuGet.org
- Located in `.github/workflows/publish.yml`

To publish a new version:
1. Create a new GitHub release with a version tag (e.g., `v2.0.0`, `v2.1.0-beta`)
2. The workflow will automatically:
   - Extract the version from the release tag (removing the `v` prefix)
   - Build and test the code
   - Pack the NuGet package with the extracted version
   - Publish to NuGet.org

**Important**: The NuGet package version is now automatically synchronized with the GitHub release tag. You no longer need to manually update the version in `SepaWriter.csproj`.

## Version Management

The package version is automatically extracted from GitHub release tags during the publish workflow. The base version in `SepaWriter/SepaWriter.csproj` (`2.0.0`) is only used as a fallback for local development builds.

When creating a release:
- Use tags like `v1.2.3` for stable releases (version becomes `1.2.3`)
- Use tags like `v2.0.0-beta` for pre-releases (version becomes `2.0.0-beta`)
- The workflow automatically strips the `v` prefix from tags

Follow [Semantic Versioning](https://semver.org/):
- MAJOR version for incompatible API changes
- MINOR version for backward-compatible functionality additions
- PATCH version for backward-compatible bug fixes

### Manual Version Override
To publish with a specific version without creating a release:
1. Go to Actions → Publish NuGet Package → Run workflow
2. Enter the desired version (e.g., `2.1.0`)
3. The workflow will pack and publish with that version

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

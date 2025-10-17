# Release Notes

## Version 2.0.0 (Pending Release)

### Major Changes
- **Migrated to .NET 8**: The project now targets .NET 8.0 (LTS) alongside .NET Standard 2.0 for backward compatibility
- **Modern NuGet Packaging**: All package metadata is now defined in the project file using SDK-style properties
- **CI/CD Automation**: Added GitHub Actions workflows for automated building, testing, and publishing

### Updated Dependencies
- **log4net**: 2.0.12 → 3.0.1
- **System.Text.Encoding.CodePages**: 5.0.0 → 8.0.0
- **NUnit**: 3.13.0 → 4.2.2 (test project)
- **NUnit3TestAdapter**: 3.17.0 → 4.6.0 (test project)
- **Microsoft.NET.Test.Sdk**: 16.8.3 → 17.11.1 (test project)

### Security Improvements
- Resolved high and moderate severity vulnerabilities present in .NET Core 2.2 and 3.1
- Updated all dependencies to their latest stable versions

### New Features
- **Symbol Package Support**: `.snupkg` symbol packages are now generated for improved debugging experience
- **Automated Builds**: CI/CD pipeline automatically builds and tests code on every push
- **Automated Publishing**: Package publishing to NuGet.org on GitHub releases

### Documentation
- Updated README with .NET 8 requirements and NuGet installation instructions
- Added CONTRIBUTING.md for contributors
- Added BUILD_AND_PUBLISH.md with detailed build and publish instructions
- Added MIGRATION_SUMMARY.md documenting the migration process

### Breaking Changes for Developers
- Minimum required SDK for building: .NET 8.0
- No breaking changes for library consumers

### Compatibility
- Continues to support .NET Standard 2.0, ensuring compatibility with:
  - .NET Framework 4.6.1+
  - .NET Core 2.0+
  - .NET 5+
  - Mono 5.4+
  - Unity 2018.1+

### Bug Fixes
None - This is a maintenance release focused on modernization

---

## Version 1.0.3.0 (Previous)

Last release on the legacy framework stack (netcoreapp3.1, netcoreapp2.2, netstandard2.0).

---

## How to Upgrade

### For Library Consumers
Simply update the NuGet package:
```bash
dotnet add package Perrich.SepaWriter --version 2.0.0
```

No code changes are required. The API remains fully compatible.

### For Contributors
1. Install .NET 8.0 SDK or later
2. Clone the repository
3. Run `dotnet build` and `dotnet test`

See CONTRIBUTING.md for more details.

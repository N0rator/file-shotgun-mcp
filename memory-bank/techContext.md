# Technical Context: FileShotgunMcpServer

## Technologies Used

### Core Framework
- **.NET 9.0**: The latest version of Microsoft's development platform, providing modern language features and performance improvements.

### Dependencies
- **Microsoft.Extensions.Hosting**: Provides generic host builder functionality for configuring and running the application.
- **Microsoft.Extensions.DependencyInjection**: Implements dependency injection for services.
- **Microsoft.Extensions.Logging**: Provides logging capabilities.
- **ModelContextProtocol (v0.3.0-preview.3)**: Implements the Model Context Protocol server functionality.

## Development Setup

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio 2022 or later (recommended) or any other .NET-compatible IDE

### Development Environment
- Windows, macOS, or Linux (any platform that supports .NET 9.0)
- Command-line tools for building and publishing

### Build Process
1. Clone the repository
2. Open the solution in Visual Studio or use the .NET CLI
3. Build the solution
4. Publish the application for deployment

## Technical Constraints

### Platform Compatibility
- Must run on any platform that supports .NET 9.0
- Must work with standard I/O for communication

### Performance Requirements
- Should efficiently handle reading multiple files
- Should minimize memory usage when processing large memory banks

### Security Considerations
- Access to the file system is limited to the specified memory bank directory
- No network access is required for core functionality

## Dependencies

### External Dependencies
- **ModelContextProtocol**: Critical dependency for implementing the MCP server
- **Microsoft.Extensions.Hosting**: Required for application hosting
- **Microsoft.Extensions.DependencyInjection**: Required for service configuration
- **Microsoft.Extensions.Logging**: Required for logging

### Internal Dependencies
- **Tool.cs**: Implements the ReadMemoryBank tool
- **Program.cs**: Configures and starts the MCP server

## Tool Usage Patterns

### ReadMemoryBank Tool
- **Input**: Absolute path to a memory bank folder
- **Process**: Reads all .md files in the folder
- **Output**: Returns a single string with all file contents, separated by delimiters
- **Usage Pattern**:
  ```csharp
  string memoryBankContent = ReadMemoryBank("/path/to/memory-bank");
  // Parse the content by splitting on delimiters
  ```

### Delimiter Format
- File start: `*#*#*[filepath]*#*#*begin*#*#*`
- File end: `*#*#*end*#*#*`
- This format allows for easy parsing and identification of individual files within the combined payload

## Configuration
- No external configuration files are required
- All configuration is done through code in Program.cs
- Logging is configured to send errors to stderr

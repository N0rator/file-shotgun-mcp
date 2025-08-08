# FileShotgunMcpServer

<div align="center">

![FileShotgunMcpServer Logo](https://img.shields.io/badge/FileShotgun-MCP%20Server-blue?style=for-the-badge)

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat-square&logo=dotnet)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)](LICENSE)
[![MCP](https://img.shields.io/badge/MCP-0.3.0--preview.3-orange?style=flat-square)](https://github.com/modelcontextprotocol)

**A specialized MCP server for efficient memory bank file access**

</div>

## 🚀 Overview

FileShotgunMcpServer is a lightweight Model Context Protocol (MCP) server that provides tools for working with memory banks. Its primary purpose is to read all markdown files from a memory bank directory and return them as a single, well-structured text payload.

This server simplifies the process of accessing memory bank files for AI assistants, providing a consistent format for memory bank content and enabling efficient access to memory bank information.

## ✨ Features

- 📚 **Memory Bank Reading**: Read all markdown files from a memory bank directory
- 📝 **Memory Bank Updating**: Update multiple memory bank files in a single operation
- 🔄 **Structured Output**: Return memory bank content with clear delimiters
- 🔌 **MCP Integration**: Seamlessly integrate with AI assistants through the Model Context Protocol
- 🚀 **Standard I/O Transport**: Simple communication through standard input/output
- 🛠️ **Minimal Dependencies**: Lightweight implementation with few external dependencies

## 📋 Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download) or later

## 🔧 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/N0rator/file-shotgun-mcp.git
   cd file-shotgun-mcp
   ```

2. **Publish the solution**
   ```bash
   dotnet publish -c Release
   ```

3. **Copy the built result to your desired location**
   ```bash
   # Example: Copy to C:\MCP\FileShotgunMcpServer
   mkdir -p C:\MCP\FileShotgunMcpServer
   cp -r bin/Release/net9.0/publish/* C:\MCP\FileShotgunMcpServer/
   ```

4. **Add to Cline MCP servers configuration**
   
   Add the following to your Cline MCP servers configuration:
   ```json
   "FileShotgunMcpServer": {
     "disabled": false,
     "timeout": 60,
     "type": "stdio",
     "command": "dotnet",
     "args": [
       "C:\\MCP\\FileShotgunMcpServer\\FileShotgunMcpServer.dll"
     ],
     "env": {}
   }
   ```

## 🔍 Usage

Once configured, the FileShotgunMcpServer provides the following tools:

### ReadMemoryBank

Reads all markdown files from a specified memory bank directory and returns them as a single, structured text payload.

**Input Parameters:**
- `memoryBankFolderPath`: An absolute path to the memory bank folder

**Example Output:**
```
*#*#*/path/to/memory-bank/file1.md*#*#*begin*#*#*
# File 1 Content
This is the content of file 1.
*#*#*end*#*#*
*#*#*/path/to/memory-bank/file2.md*#*#*begin*#*#*
# File 2 Content
This is the content of file 2.
*#*#*end*#*#*
```

### UpdateMemoryBank

Updates multiple memory bank files in a single operation and returns the updated memory bank content as a structured text payload.

**Input Parameters:**
- `memoryBankUpdateScenario`: An object containing:
  - `memoryBankFolderPath`: An absolute path to the memory bank folder
  - `fileUpdates`: An array of file updates, each with:
    - `fileName`: The name of the file to update
    - `operations`: An array of operations, each with:
      - `oldValue`: The content to replace
      - `newValue`: The new content

**Example Input:**
```json
{
  "memoryBankFolderPath": "/path/to/memory-bank",
  "filesUpdates": [
    {
      "fileName": "file1.md",
      "operations": [
        {
          "oldValue": "# Old Title",
          "newValue": "# New Title"
        }
      ]
    }
  ]
}
```

**Example Output:**
Same format as ReadMemoryBank, but with the updated content.

**Note:** The tool automatically normalizes line endings in the oldValue and newValue strings to match the platform's line endings, ensuring consistent replacements regardless of how the strings are formatted.

### ⚙️ Best Practices for AI Integration

<div align="center">
  
  <img src="https://img.shields.io/badge/RECOMMENDED-Rules%20File-brightgreen?style=for-the-badge" alt="Recommended Rules File"/>
  
</div>

> 📝 **IMPORTANT**: For optimal AI assistant integration, create a rules file in your Cline AI configuration directory.

Create a file named `file-shotgun.md` with the following content:

```markdown
# Strict rules
* When you want to read all of memory-bank files or the whole memory-bank, use "read_memory_bank" tool of "FileShotgunMcpServer" mcp server.
* When you want to update multiple memory-bank files, use "update_memory_bank" tool of "FileShotgunMcpServer" mcp server.
```

This rule ensures that AI assistants will use the FileShotgunMcpServer's specialized tools for memory bank operations, providing better performance and consistent formatting of memory bank content.

## 🤝 Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.

## 📄 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgments

- [Model Context Protocol](https://github.com/modelcontextprotocol) for providing the MCP server framework
- [.NET](https://dotnet.microsoft.com/) for the development platform

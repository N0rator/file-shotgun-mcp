# Active Context: FileShotgunMcpServer

## Current Work Focus
The current focus is on establishing the core functionality of the FileShotgunMcpServer as an MCP server that provides memory bank reading and updating capabilities. The implementation includes two tools: ReadMemoryBank, which reads all markdown files from a specified directory and returns them as a structured text payload, and UpdateMemoryBank, which allows updating multiple memory bank files in a single operation.

## Recent Changes
- Initial project setup with .NET 9.0
- Implementation of the MCP server using the ModelContextProtocol library
- Creation of the ReadMemoryBank tool
- Creation of the UpdateMemoryBank tool with line ending normalization
- Configuration of logging to stderr
- Setup of standard I/O for server transport
- Updated documentation to reflect the current state of the project
- Fixed repository URL in documentation

## Next Steps
1. **Testing**: Implement comprehensive tests for both ReadMemoryBank and UpdateMemoryBank tools
2. **Documentation**: Enhance documentation with usage examples for both tools
3. **Error Handling**: Improve error handling for file access issues
4. **Performance Optimization**: Optimize file reading and updating for large memory banks
5. **Additional Tools**: Consider adding more memory bank-related tools

## Active Decisions and Considerations

### Tool Implementation
- **Decision**: Implement ReadMemoryBank and UpdateMemoryBank as static methods with attributes
- **Status**: Implemented
- **Considerations**: This approach provides a clean, declarative way to define tool capabilities and simplifies registration

### UpdateMemoryBank Implementation
- **Decision**: Use a structured input object for update operations
- **Status**: Implemented
- **Considerations**: This approach provides a clear way to specify multiple file updates in a single operation

### Line Ending Normalization
- **Decision**: Normalize line endings in the oldValue and newValue strings
- **Status**: Implemented
- **Considerations**: This ensures consistent replacements regardless of how the strings are formatted

### Delimiter Format
- **Decision**: Use `*#*#*[filepath]*#*#*begin*#*#*` and `*#*#*end*#*#*` as delimiters
- **Status**: Implemented
- **Considerations**: These delimiters are unlikely to appear in normal markdown content and provide clear separation between files

### File Filtering
- **Decision**: Only include .md files in the memory bank
- **Status**: Implemented
- **Considerations**: This focuses the tool on markdown files, which are the standard format for memory bank content

## Important Patterns and Preferences

### Code Organization
- Keep the codebase minimal and focused
- Use standard .NET patterns and practices
- Leverage attributes for declarative tool definitions

### Error Handling
- Log errors to stderr
- Provide clear error messages
- Handle file access exceptions gracefully

### Performance Considerations
- Read files sequentially to minimize memory usage
- Use StringBuilder for efficient string concatenation
- Consider streaming for very large memory banks in future versions

## Learnings and Project Insights

### MCP Integration
- The ModelContextProtocol library provides a simple way to create tools for AI assistants
- Standard I/O transport is sufficient for most use cases
- Tool attributes provide a clean way to define tool capabilities

### Memory Bank Pattern
- Memory banks are an effective way to maintain context between AI sessions
- Structured access to memory bank files improves AI assistant effectiveness
- Delimiters provide a simple way to separate files in a combined payload

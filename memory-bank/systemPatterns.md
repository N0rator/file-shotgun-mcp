# System Patterns: FileShotgunMcpServer

## System Architecture
FileShotgunMcpServer follows a simple, focused architecture designed around the Model Context Protocol (MCP) server pattern:

```
┌─────────────────────────────────┐
│       FileShotgunMcpServer      │
├─────────────────────────────────┤
│                                 │
│  ┌─────────────┐ ┌───────────┐  │
│  │ MCP Server  │ │   Tools   │  │
│  │ Framework   ├─┤           │  │
│  │             │ │ReadMemory │  │
│  └─────────────┘ │   Bank    │  │
│                  │           │  │
│                  │UpdateMemory│  │
│                  │   Bank    │  │
│                  └───────────┘  │
│                                 │
└─────────────────────────────────┘
```

## Key Technical Decisions

### 1. MCP Server Implementation
- **Decision**: Use the ModelContextProtocol library to implement the MCP server.
- **Rationale**: Provides a standardized way to create tools that can be used by AI assistants.
- **Benefit**: Simplifies integration with AI platforms that support the MCP standard.

### 2. Standard I/O Transport
- **Decision**: Use standard I/O for server transport.
- **Rationale**: Provides a simple, universal interface that works across different environments.
- **Benefit**: Reduces complexity and dependencies compared to network-based transports.

### 3. Tool Registration
- **Decision**: Automatically register tools from the assembly.
- **Rationale**: Simplifies adding new tools in the future.
- **Benefit**: Reduces boilerplate code and potential for registration errors.

### 4. Memory Bank Reading Approach
- **Decision**: Read all files at once and return as a single payload with delimiters.
- **Rationale**: Provides a complete context in a single operation.
- **Benefit**: Simplifies client-side processing and ensures complete context.

## Design Patterns in Use

### 1. Dependency Injection
- Used for configuring services and logging.
- Improves testability and modularity.

### 2. Tool Pattern
- Tools are implemented as static methods with attributes.
- Provides a clean, declarative way to define tool capabilities.

### 3. Builder Pattern
- Used for configuring the host and services.
- Provides a fluent API for configuration.

## Component Relationships
- **Host**: The top-level container that manages the application lifecycle.
- **MCP Server**: Handles MCP protocol communication.
- **Tools**: Implement specific functionality (ReadMemoryBank and UpdateMemoryBank).
- **Logging**: Provides error reporting through stderr.

## Critical Implementation Paths
1. **Server Initialization**: 
   - Create application builder
   - Configure logging
   - Add MCP server
   - Configure transport
   - Register tools
   - Build and run

2. **Tool Execution**:
   - Receive tool request
   - Validate parameters
   - Execute tool logic
   - Return structured response

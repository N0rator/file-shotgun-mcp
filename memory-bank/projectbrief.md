# Project Brief: FileShotgunMcpServer

## Overview
FileShotgunMcpServer is a .NET application that implements a Model Context Protocol (MCP) server. Its primary purpose is to provide tools for working with memory banks, specifically the ability to read all markdown files from a memory bank directory and return them as a single, well-structured text payload.

## Core Requirements
1. Implement an MCP server that can be integrated with Cline AI assistant
2. Provide a tool for reading memory bank files efficiently
3. Provide a tool for updating multiple memory bank files in a single operation
4. Return memory bank content in a structured format that can be easily parsed
5. Support standard I/O for server transport
6. Maintain minimal dependencies and a lightweight footprint

## Goals
- Simplify the process of reading and updating memory bank files for AI assistants
- Provide a consistent format for memory bank content
- Enable efficient access to and modification of memory bank information
- Support the memory bank pattern for maintaining context between AI sessions
- Facilitate better context management for AI assistants

## Scope
The project focuses specifically on memory bank file access and does not attempt to implement other MCP server functionalities beyond what's necessary for this purpose.

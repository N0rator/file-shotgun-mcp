namespace FileShotgunMcpServer.Tools.MemoryBank;

internal static class Constants
{
    internal static class ToolsDescriptions
    {
        internal const string ReadMemoryBank = """
            Explodes an entire memory-bank into a single, well‑structured text payload.
            """;

        internal const string UpdateMemoryBank = """
            Updates an entire memory-bank in a single request. Returns updated memory-bank in a single, well‑structured text payload.
            """;
    }

    internal static class ToolsArgumentDescriptions
    {
        internal const string MemoryBankFolderPath = """
            An absolute path to memory-bank folder.
            """;

        internal const string FilesUpdates = """
            A complete collection of operations that should be performed against memory bank files.
            File names must match the names of files in the memory bank folder and contain file extension.
            """;
    }
}

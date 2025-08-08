using ModelContextProtocol.Server;
using System.ComponentModel;

namespace FileShotgunMcpServer.Tools.MemoryBank;

public static partial class MemoryBankToolsAggregation
{
    [McpServerTool, Description(Constants.ToolsDescriptions.UpdateMemoryBank)]
    public static string UpdateMemoryBank(
        [Description(Constants.ToolsArgumentDescriptions.MemoryBankFolderPath)] string memoryBankFolderPath,
        [Description(Constants.ToolsArgumentDescriptions.FilesUpdates)] FileUpdateScenario[] filesUpdates)
    {
        var files = Directory.GetFiles(memoryBankFolderPath, "*.md");
        foreach (var filePath in files)
        {
            var filename = Path.GetFileName(filePath);
            var fileUpdates = filesUpdates
                .FirstOrDefault(update => update.FileName == filename);

            if (fileUpdates == null)
            {
                continue;
            }

            var content = File.ReadAllText(filePath);

            foreach (var operation in fileUpdates.Operations)
            {
                var oldValue = operation.oldValue.NormalizeLineEndings();
                var newValue = operation.newValue.NormalizeLineEndings();
                content = content.Replace(oldValue, newValue);
            }

            File.WriteAllText(filePath, content);
        }

        return ReadMemoryBank(memoryBankFolderPath);
    }

    public record FileUpdateScenario(
        string FileName,
        ReplaceOperation[] Operations
    );

    public record ReplaceOperation(
        string oldValue,
        string newValue
    );

    private static string NormalizeLineEndings(this string content) =>
        content.Replace("\r\n", "\n").Replace("\n", System.Environment.NewLine);
}

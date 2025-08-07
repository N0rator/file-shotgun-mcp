using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text;

namespace FileShotgunMcpServer.Tools.MemoryBank;

[McpServerToolType]
public static class Tool
{
    [McpServerTool, Description("Explodes an entire memory-bank into a single, well‑structured text payload.")]
    public static string ReadMemoryBank(
        [Description("An absolute path to memory-bank folder")] string memoryBankFolderPath)
    {
        var files = Directory.GetFiles(memoryBankFolderPath, "*.md");

        var sb = new StringBuilder();

        foreach (var file in files)
        {
            sb.AppendLine($"*#*#*{file}*#*#*begin*#*#*`");
            sb.AppendLine(File.ReadAllText(file));
            sb.AppendLine("*#*#*end*#*#*");
        }

        return sb.ToString();
    }
}

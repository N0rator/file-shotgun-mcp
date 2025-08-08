using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Text;

namespace FileShotgunMcpServer.Tools.MemoryBank;

public static partial class MemoryBankToolsAggregation
{
    [McpServerTool, Description(Constants.ToolsDescriptions.ReadMemoryBank)]
    public static string ReadMemoryBank(
        [Description(Constants.ToolsArgumentDescriptions.MemoryBankFolderPath)] string memoryBankFolderPath)
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

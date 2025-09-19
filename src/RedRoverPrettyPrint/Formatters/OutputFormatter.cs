using System.Text;
using RedRoverPrettyPrint.Models;

namespace RedRoverPrettyPrint.Foramtters;

public static class OutputFormatter
{
    public static string FormatAsPrettyPrint(Node node, bool alphabatize)
    {
        var stringBuilder = new StringBuilder();
        FormatNodes(node, stringBuilder, -1, alphabatize);
        return stringBuilder.ToString();
    }

    private static void FormatNodes(
        Node node,
        StringBuilder stringBuilder,
        int depth,
        bool alphabatize)
    {
        if (depth >= 0)
        {
            stringBuilder.AppendLine($"{new string(' ', 2 * depth)}- {node.Value}");
        }

        IEnumerable<Node> childNodes = node.Children;
        if (alphabatize) childNodes = node.Children.OrderBy(kid => kid.Value);

        foreach (Node kid in childNodes)
        {
            FormatNodes(kid, stringBuilder, depth + 1, alphabatize);
        }
    }
}
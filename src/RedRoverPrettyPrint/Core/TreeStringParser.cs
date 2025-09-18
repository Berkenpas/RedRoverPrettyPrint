using System.Text;
using RedRoverPrettyPrint.Foramtters;
using RedRoverPrettyPrint.Models;

namespace RedRoverPrettyPrint.Core;

public class TreeStringParser : ITreeStringParser
{
    public string Parse(string inputString, bool alphabatize)
    {
        string cleanInputString = inputString.Trim().Trim('(', ')');

        Node root = new Node("root");

        Node fullTree = ParseNodes(inputString, root);

        if (alphabatize) return OutputFormatter.AlphabatizeFormat(fullTree);

        return OutputFormatter.Format(fullTree);
    }

    private static Node ParseNodes(string inputString, Node parent)
    {
        List<string> elements = SplitByCommaAndParentheses(inputString);

        foreach (string word in elements)
        {
            string trimmedWord = word.Trim();
            if (string.IsNullOrWhiteSpace(trimmedWord)) continue;

            if (HasNestedContent(trimmedWord))
            {
                string subParentValue = ExtractParentName(trimmedWord);
                string nestedChildren = ExtractChildren(trimmedWord);

                var subParent = new Node(subParentValue);
                parent.Children.Add(subParent);

                ParseNodes(nestedChildren, subParent);
            }
            else
            {
                parent.Children.Add(new Node(trimmedWord));
            }
        }

        return parent;
    }

    private static List<string> SplitByCommaAndParentheses(string inputString)
    {
        var result = new List<string>();
        string[] words = inputString.Split(',');
        StringBuilder currentGroup = new StringBuilder();
        int totalOpenParentheses = 0;

        foreach (string word in words)
        {
            int localOpenParens = word.Count(chr => chr == '(');
            int localClosedParens = word.Count(chr => chr == ')');

            if (totalOpenParentheses == 0 && localOpenParens == 0)
            {
                result.Add(word.Trim());
            }
            else
            {
                if (currentGroup.Length > 0)
                    currentGroup.Append(", ");

                currentGroup.Append(word);
                totalOpenParentheses += localOpenParens - localClosedParens;

                if (totalOpenParentheses == 0)
                {
                    result.Add(currentGroup.ToString().Trim());
                    currentGroup.Clear();
                }
            }
        }

        return result;
    }

    private static bool HasNestedContent(string word)
    {
        throw new NotImplementedException();
    }

    private static string ExtractParentName(string word)
    {
        throw new NotImplementedException();
    }

    private static string ExtractChildren(string word)
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RedRoverPrettyPrint.Foramtters;
using RedRoverPrettyPrint.Models;

namespace RedRoverPrettyPrint.Core;

public class TreeStringParser : ITreeStringParser
{
    public string Parse(string inputString, bool alphabatize)
    {
        string cleanInputString = inputString.Trim().Trim('(', ')');

        Node root = new Node("root");

        Node fullTree = ParseNodes(inputString);

        if (alphabatize) return OutputFormatter.AlphabatizeFormat(fullTree);

        return OutputFormatter.Format(fullTree);
    }

    private static Node ParseNodes(string inputString, Node root)
    {
        List<string> elements = SplitByCommaAndParentheses(inputString);

        foreach (string word in elements)
        {
            string trimmedWord = word.Trim();
            if (string.IsNullOrWhiteSpace(trimmedWord)) continue;

            if (is child)
            {
                root.Children.Add(new Node());
            }
            else {
                root.Children.Add(new Node(trimmedWord));
            }
        }

        return root;
    }

    private static List<string> SplitByCommaAndParentheses(inputstring)
    {
        throw new NotImplementedException();
    }
}

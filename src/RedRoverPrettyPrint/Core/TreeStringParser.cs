using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedRoverPrettyPrint.Foramtters;
using RedRoverPrettyPrint.Models;

namespace RedRoverPrettyPrint.Core;

public class TreeStringParser : ITreeStringParser
{
    public string Parse(string inputString, bool alphabatize)
    {
        Node fullTree = ParseNode(inputString);

        if (alphabatize) return OutputFormatter.AlphabatizeFormat(fullTree);

        return OutputFormatter.Format(fullTree);
    }

    private static Node ParseNode(string inputString)
    {
        //Trim and split off of spaces

        //Create root node
        Node root = new Node("root");

        //Iterate through and add child nodes or base nodes

        return root;
    }
}

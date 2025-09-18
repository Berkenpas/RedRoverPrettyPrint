namespace RedRoverPrettyPrint.Models;

public class Node
{
    public string Value { get; set; }

    public List<Node> Children { get; set; } = new List<Node>();

    public Node(string value)
    {
        Value = value;
    }

    public Node(string value, List<Node> children)
    {
        Value = value;
        Children = children;
    }
}
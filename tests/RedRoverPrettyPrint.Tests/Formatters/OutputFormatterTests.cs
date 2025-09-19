using RedRoverPrettyPrint.Foramtters;
using RedRoverPrettyPrint.Models;
using RedRoverPrettyPrint.Tests.Utility;
using Xunit;

namespace RedRoverPrettyPrint.Tests.Formatters;


public class OutputFormatterTests
{
    [Fact]
    public void FormatAsPrettyPrint_SimpleNode_ReturnsCorrectFormat()
    {
        // Arrange
        var root = new Node("root");
        root.Children.Add(new Node("id"));
        root.Children.Add(new Node("name"));
        
        // Act
        string result = OutputFormatter.FormatAsPrettyPrint(root, false);
        
        // Assert
        string expected = "- id\n- name\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }
}
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

    [Fact]
    public void FormatAsPrettyPrint_NestedNodes_ReturnsCorrectIndentation()
    {
        // Arrange
        var root = new Node("root");
        var typeNode = new Node("type");
        typeNode.Children.Add(new Node("id"));
        typeNode.Children.Add(new Node("name"));
        root.Children.Add(typeNode);

        // Act
        string result = OutputFormatter.FormatAsPrettyPrint(root, false);

        // Assert
        string expected = "- type\n  - id\n  - name\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void FormatAsPrettyPrint_AlphabetizedNodes_ReturnsSortedOutput()
    {
        // Arrange
        var root = new Node("root");
        root.Children.Add(new Node("november"));
        root.Children.Add(new Node("alpha"));
        root.Children.Add(new Node("charlie"));

        // Act
        string result = OutputFormatter.FormatAsPrettyPrint(root, true);

        // Assert
        string expected = "- alpha\n- charlie\n- november\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void FormatAsPrettyPrint_DeepNesting_ReturnsCorrectIndentation()
    {
        // Arrange
        var root = new Node("root");
        var level1 = new Node("level1");
        var level2 = new Node("level2");
        var level3 = new Node("level3");

        level2.Children.Add(level3);
        level1.Children.Add(level2);
        root.Children.Add(level1);

        // Act
        string result = OutputFormatter.FormatAsPrettyPrint(root, false);

        // Assert
        string expected = "- level1\n  - level2\n    - level3\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void FormatAsPrettyPrint_EmptyRoot_ReturnsEmptyString()
    {
        // Arrange
        var root = new Node("root");

        // Act
        string result = OutputFormatter.FormatAsPrettyPrint(root, false);

        // Assert
        Assert.Equal("", TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void FormatAsPrettyPrint_NestedAlphabetization_SortsAtEachLevel()
    {
        // Arrange
        var root = new Node("root");
        
        var parent1 = new Node("zulu");
        parent1.Children.Add(new Node("golf"));
        parent1.Children.Add(new Node("alpha"));
        
        var parent2 = new Node("apple");
        parent2.Children.Add(new Node("delta"));
        parent2.Children.Add(new Node("beta"));
        
        root.Children.Add(parent1);
        root.Children.Add(parent2);
        
        // Act
        string result = OutputFormatter.FormatAsPrettyPrint(root, true);
        
        // Assert
        string expected = "- apple\n  - beta\n  - delta\n- zulu\n  - alpha\n  - golf\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }
}
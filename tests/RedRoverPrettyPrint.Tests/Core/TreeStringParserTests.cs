using RedRoverPrettyPrint.Core;
using RedRoverPrettyPrint.Tests.Utility;
using Xunit;

namespace RedRoverPrettyPrint.Tests.Core;

public class TreeStringParserTests
{
    [Fact]
    public void Parse_SimpleElements_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "(id, name, email)";

        // Act
        string result = TreeStringParser.Parse(input, false);

        // Assert
        string expected = "- id\n- name\n- email\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void Parse_SimpleElementsAndAlphabetized_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "(id, name, email)";
        
        // Act
        string result = TreeStringParser.Parse(input, true);
        
        // Assert
        string expected = "- email\n- id\n- name\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void Parse_SingleNestedLevel_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "(id, name, type(id, name))";
        
        // Act
        string result = TreeStringParser.Parse(input, false);
        
        // Assert
        string expected = "- id\n- name\n- type\n  - id\n  - name\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void Parse_ComplexNestedStructure_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
        
        // Act
        string result = TreeStringParser.Parse(input, false);
        
        // Assert
        string expected = "- id\n- name\n- email\n- type\n  - id\n  - name\n  - customFields\n    - c1\n    - c2\n    - c3\n- externalId\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void Parse_ComplexNestedStructureAndAlphabetized_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";
        
        // Act
        string result = TreeStringParser.Parse(input, true);
        
        // Assert
        string expected = "- email\n- externalId\n- id\n- name\n- type\n  - customFields\n    - c1\n    - c2\n    - c3\n  - id\n  - name\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void Parse_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string input = "()";
        
        // Act
        string result = TreeStringParser.Parse(input, false);
        
        // Assert
        Assert.Equal("", TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void Parse_SingleElement_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "(id)";
        
        // Act
        string result = TreeStringParser.Parse(input, false);
        
        // Assert
        string expected = "- id\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void Parse_MultipleNestedLevels_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "(a(b(c, d), e), f)";
        
        // Act
        string result = TreeStringParser.Parse(input, false);
        
        // Assert
        string expected = "- a\n  - b\n    - c\n    - d\n  - e\n- f\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }

    [Fact]
    public void Parse_WhitespaceHandling_ReturnsCorrectOutput()
    {
        // Arrange
        string input = "( id , name , email )";
        
        // Act
        string result = TreeStringParser.Parse(input, false);
        
        // Assert
        string expected = "- id\n- name\n- email\n";
        Assert.Equal(expected, TestUtility.NormalizeLineEndings(result));
    }
}

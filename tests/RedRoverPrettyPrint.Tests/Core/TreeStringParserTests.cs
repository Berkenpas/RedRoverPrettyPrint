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
    

}

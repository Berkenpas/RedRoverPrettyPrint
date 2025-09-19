namespace RedRoverPrettyPrint.Tests.Utility;

public static class TestUtility
{
    internal static string NormalizeLineEndings(string input)
    {
        return input?.Replace("\r\n", "\n").Replace("\r", "\n");
    }
}
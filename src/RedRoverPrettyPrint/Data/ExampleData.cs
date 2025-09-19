namespace RedRoverPrettyPrint.Data
{
    public static class ExampleData
    {
        public static readonly Dictionary<string, string> Examples = new()
        {
            { "providedSample", "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)" },
            { "longerExample", "(id, name, email, type(id, name, customFields(c1, c2, c3, c4, c5, c6)), type(id, name, customFields(c1)), externalId)" },
        };
    }
}
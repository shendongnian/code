    public class gridQueries
    {
        ....
        public string propertiesCombinedNamesQuery { get; set; } =
            "SELECT [NameId], [CombinedName] AS Display FROM [Names] ORDER BY [CombinedName]";
        ....
    }

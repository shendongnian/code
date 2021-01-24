    public class gridQueries
    {
        ....
        public string propertiesCombinedNamesQuery() 
        {
            return "SELECT [NameId], [CombinedName] AS Display FROM [Names] ORDER BY [CombinedName]";
        }
        ....
    } 

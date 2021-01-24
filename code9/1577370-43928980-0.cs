    public static IEnumerable<KeyValuePair<int?, string>> KeyValueList()
    {
        const string sql = @"SELECT  Key ,
                            Value
                    FROM    Constants";
        var result = DataStoreReader.Query(ConnectionHelper.GetConnectionString, sql)
                                    .Select(item => new KeyValuePair<int?, string>(item.Key, item.Value))
                                    .ToList();
        //Insert the first/default element
        result.Insert(0, new KeyValuePair<int?, string>(null, "Select"));
        return result;
    }

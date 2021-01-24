    public void Components(int orderTypeId, string orderTypeKey, ...
        KeyValuePair<string, string> pair, ...)
    {
        object[] functionParameters = new object[]
        {
            new SqlParameter(@"OrderTypeId", orderTypeId),
            new SqlParameter(@"OrderTypeKey", orderTypeKey),
            ...
            // The KeyValuePair: in your store procedure two parameters:
            new SqlParameter(@"FilterKey", pair.Key),
            new SqlParameter(@"FilterValue", pair.Value),
        };
        const string sqlCommans = @"Exec ...
            @OrderTypeId, @OrderTypeKey, ...
            @FilterKey, @FilterValue, ...";
        this.Database.ExecuteSqlCommand(sqlComman, functionParameters);
    }

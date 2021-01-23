    using (var context = new SampleContext())
    using (var command = context.Database.GetDbConnection().CreateCommand())
    {
        command.CommandText = "GetData";
        command.CommandType = CommandType.StoredProcedure;
        context.Database.OpenConnection();
        using (var result = command.ExecuteReader())
        {
            // do something with result
        }
    }

    using (var context = new SampleContext())
    using (var command = context.Database.GetDbConnection().CreateCommand())
    {
        command.CommandText = "DELETE From Table1";
        context.Database.OpenConnection();
        command.ExecuteNonQuery();
    }

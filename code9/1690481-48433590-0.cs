    using (var db = new YourDbContext())
    {
        var cmd = db.Database.Connection.CreateCommand();
        cmd.CommandText = "[dbo].[YourProcedureName]";
        try
        {
            db.Database.Connection.Open();
            var reader = cmd.ExecuteReader();
            // Translate the rows in the current result set to a collection of objects
            var records = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<OtherRecord>(reader, "OtherRecords", MergeOption.AppendOnly);
            // Go to the next result and read those
            reader.NextResult();
            var otherRecords = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<YetOtherRecord>(reader, "YetOtherRecords", MergeOption.AppendOnly);
        }
        finally
        {
            db.Database.Connection.Close();
        }
    }

    // Just some class with two lists to contain the results.
    var result = new ContainsTheResults();
    using (var db = new YourDbContext())
    {
        using (var cmd = db.Database.Connection.CreateCommand())
        {
            cmd.CommandText = "[dbo].[YourProcedureName]";
            try
            {
                db.Database.Connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    // Translate the rows in the current result set to a collection of objects
                    using (var otherRecords = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<OtherRecord>(reader, "OtherRecords", MergeOption.AppendOnly))
                    {
                        result.OtherRecords = otherRecords.ToList();
                    }
                    // Go to the next result and read those
                    reader.NextResult();
                    using (var yetOtherRecords = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<YetOtherRecord>(reader, "YetOtherRecords", MergeOption.AppendOnly))
                    {
                        result.YetOtherRecords = yetOtherRecords.ToList();
                    }                     
                }
            }
            finally
            {
                db.Database.Connection.Close();
            }
        }
    }
    return result;

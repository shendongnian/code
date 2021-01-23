    using (var connection = new SQLitePCL.SQLiteConnection(sampleDB.sqlite))
    {
        using (var statement = connection.Prepare(@"select * from Person"))
        {
            while (statement.Step() == SQLitePCL.SQLiteResult.ROW)
            {
                //TODO
            }
        }
    }

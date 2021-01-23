    using (var connection = new SQLitePCL.SQLiteConnection("sampleDB.sqlite"))
    {
        using (var statement = connection.Prepare(@"select * from Person"))
        {
            while (statement.Step() == SQLitePCL.SQLiteResult.ROW)
            {
                //TODO. For example
                //Gets the value of the specified column by the column name.
                var Id = (long)(statement["Id"]);
                var Name = (string)statement["Name"];
                
                //Gets the value of the specified column by the column ordinal.
                //var Id = (long)(statement[0]);
                //var Name = (string)statement[1];
            }
        }
    }

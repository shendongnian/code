    myConnectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
            @"Data Source=C:\Users\Public\Database1.accdb;";
    using (var conn = new OleDbConnection(myConnectionString))
    {
        conn.Open();
        using (var cmd = new OleDbCommand("SELECT * FROM [qry_aFruits]", conn))
        {
            using (OleDbDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Console.WriteLine(rdr["fruit"]);
                }
            }
        }
    }

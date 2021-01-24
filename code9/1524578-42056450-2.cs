    myConnectionString =
            @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};" +
            @"Dbq=C:\Users\Public\Database1.accdb;";
    using (var conn = new OdbcConnection(myConnectionString))
    {
        conn.Open();
        using (var cmd = new OdbcCommand("SELECT * FROM [qry_aFruits]", conn))
        {
            using (OdbcDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Console.WriteLine(rdr["fruit"]);
                }
            }
        }
    }

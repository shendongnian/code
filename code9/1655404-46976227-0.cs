    connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Public\Database1.accdb";
    using (var conn = new OleDbConnection(connStr))
    {
        conn.Open();
        string sql = 
                @"SELECT " +
                @"    sqlserverTable.id, " +
                @"    accessTable.[Last Name] AS lname_a, " +
                @"    sqlserverTable.last_name AS lname_s " +
                @"FROM " +
                @"    Donor AS accessTable " +
                @"    INNER JOIN " +
                @"    [ODBC;DRIVER=SQL Server;SERVER=.\SQLEXPRESS;DATABASE=myDb;Trusted_Connection=yes].Donor AS sqlserverTable " +
                @"        ON accessTable.[Donor ID] = sqlserverTable.id";
        using (var cmd = new OleDbCommand(sql, conn))
        using (var rdr = cmd.ExecuteReader())
        {
            while (rdr.Read())
            {
                Console.WriteLine("{0} | {1}", rdr["lname_a"], rdr["lname_s"]);
            }
        }
    }

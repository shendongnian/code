    public (string, string) FindClientByMobile(string mobile)
    {
        string query = @"SELECT Cname, Caddress FROM Clients WHERE Cmobile LIKE @mobile + '*'";
        using (var conn = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data source=|DataDirectory|\\crepeDB.accdb;"))
        using (var cmd = System.Data.OleDb.OleDbCommand(query, conn))
        {
            cmd.Parameters.Add("@mobile", System.Data.OleDb.OleDbType.Integer).Value = mobile;
            conn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                rdr.Read();
                return (rdr["Cname"].ToString(), rdr["Caddress"].ToString());
            }
        }
    }

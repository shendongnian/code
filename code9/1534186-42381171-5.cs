    public void clientsearch()
    {
        string query = @"select Cname, Caddress  From Clients where Cmobile LIKE  @mobile + '*'";
        using (var conn = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data source=|DataDirectory|\\crepeDB.accdb;"))
        using (var cmd = System.Data.OleDb.OleDbCommand(query, conn))
        {
            cmd.Parameters.Add("@mobile", System.Data.OleDb.OleDbType.Integer).Value = textBox11.Text;
            conn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                if (rdr.Read())
                {
                    textBox12.Text = rdr["Cname"].ToString();
                    textBox13.Text = rdr["Caddress"].ToString();
                }
                rdr.Close();
            }
        }
    }

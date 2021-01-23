    public List<string> GetDatabaseList()
    {
        List<string> list = new List<string>();
        string conString = "server=ServerName;uid=sa;pwd=Password;";
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(dr[0].ToString());
                    }
                }
            }
        }
        return list;
    }

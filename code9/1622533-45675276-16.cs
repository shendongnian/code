    private Dictionary<string, string> connectionrepositroylist;
        private SqlConnection GetConnection(String dbname)
        {
            SqlConnection con = null;
            if(connectionrepositroylist.ContainsKey(dbname))
            {
                con = new SqlConnection(connectionrepositroylist[dbname]);
            }
            return con;
        }

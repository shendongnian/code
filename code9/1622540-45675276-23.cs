    public class DatabaseConnector
    {
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
        public void Execute(String dbname, Action<SqlConnection> action)
        {
            using (var cnn = GetConnection(dbname))
            {
                if (cnn != null) // in case dbname is not in the list...
                {
                    cnn.Open();
                    action(cnn);
                }
            }
        }
        
        // Of course, You will need a way to populate your dictionary - 
        // I suggest having a couple of methods like this to add, update and remove items.
        public bool AddOrUpdateDataBaseName(string dbname, string connectionString)
        {
            if(connectionrepositroylist.ContainsKey(dbname))
            {
                connectionrepositroylist[dbname] = connectionString;
            }
            else
            {
                connectionrepositroylist.Add(dbname, connectionString);
            }
        }
    }

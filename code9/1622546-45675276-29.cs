    public class DatabaseConnector
    {
        private Dictionary<string, string> connectionrepositroylist;
        private string GetConnectionString(String dbname)
        {
            return connectionrepositroylist.ContainsKey(dbname) ? connectionrepositroylist[dbname] : "";
        }
        public void Execute(String dbname, Action<SqlConnection> action)
        {
            var connectionString = GetConnectionString(dbname);
            if(!string.IsNullOrEmpty(connectionString))
            {    
                using (var cnn = new SqlConnection(connectionString))
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

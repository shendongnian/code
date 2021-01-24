    public class RepoItem
    {
        public string databasename;
        public SqlConnection sqlcnn;
    }
    
    public class DatabaseConnector
    {
        private List<RepoItem> connectionrepositroylist;
    
        private SqlConnection GetConnection(String dbname)
        {
            return (from n in connectionrepositroylist
                    where n.databasename == dbname
                    select n.sqlcnn).SingleOrDefault();
        }
        public void Execute(String dbname, Action<SqlConnection> action)
        {
            using (var cnn = GetConnection(dbname))
            {
                if (cnn != null) // in case dbname is not in the list...
                {
                    cnn.Open();
                    action(cnn);
                    cnn.Close();
                }
            }
        }
    }

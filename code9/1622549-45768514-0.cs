    public class RepoItem
    {
        public string databasename;
        public SqlConnection sqlcnn;
    }
    
    public class ConnectionRepository
    {
        private List<RepoItem> connectionrepositroylist;
    
        public SqlConnection getConnection(String dbname)
        {
            SqlConnection cnn = (from n in connectionrepositroylist
                                 where n.databasename == dbname
                                 select n.sqlcnn).Single;
            if (cnn!= null && cnn.State == cnn.Closed) // Impelement other checks as well
            {
             cnn.Open();
            }
             return cnn;
        }
    }

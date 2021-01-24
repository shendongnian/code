    public static class ConnectionRepository
    {
        private static readonly Dictionary<string, string> Connections = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
        public static bool Contains(string key)
        {
            return Connections.ContainsKey(key);
        }
        public static void Add(string key, string connectionString)
        {
            Connections.Add(key, connectionString);
        }
        public static SqlConnection Get(string key)
        {
            var con = new SqlConnection(Connections[key]);
            con.Open();
            return con;
        }
    }

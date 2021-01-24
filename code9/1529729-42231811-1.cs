    public class ConnectionString
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public ConnectionString(string dataSource, string initialCatalog, string userID, string password)
        {
            DataSource = dataSource;
            InitialCatalog = initialCatalog;
            // etc.
        }
        public override string ToString()
        {
            return string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", DataSource, InitialCatalog, UserID, Password);
        }
    }

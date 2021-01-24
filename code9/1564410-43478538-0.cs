    public partial class Connection : IDisposable
    {
        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        protected static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            }
        }
        /// <summary>
        /// Default Constructor for the Database Connection Class.
        /// </summary>
        public Connection()
        {
            this.sqlConnection = new SqlConnection(Connection.ConnectionString);
            this.sqlConnection.Open();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        public void Dispose()
        {
            if (sqlConnection != null)
            {
                if (sqlConnection.State != System.Data.ConnectionState.Closed)
                    sqlConnection.Close();
                sqlConnection.Dispose();
                sqlConnection = null;
            }
        }
    }

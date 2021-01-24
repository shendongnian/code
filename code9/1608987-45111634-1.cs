    class DataAccessLayer : IDataAccessLayer
    {
        private readonly IDatabaseAuthenticationContext _dbAuthenticationContext;
        public DataAccessLayer(IDatabaseAuthenticationContext context)
        {
            _dbAuthenticationContext = context; //Injected
        }
        public void ExecuteSomeCommand()
        {
            using (var conn = new SqlConnection(this.CreateConnectionString()))
            {
                var cmd = new SqlCommand("SomeCommand");
                cmd.CommandType = StoredProcedure;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
            }
        }
        private string CreateConnectionString()
        {
            return String.Format("Server={0};UID={1};PWD={2}", this.GetServerName(),
                                                               _dbAuthenticationContext.DatabaseUserName,
                                                               _dbAuthenticationContext.Databasepassword);
        }

    public class ClassX
    {
        private RSProfile _rsprofile;
        RSDatabaseConnectionCreator _dbConnectionCreator;
        private SqlConnection _sqlConnection;
            public ClassX()
            {
               _rsProfile = xxx; //  Get the RSProfile object
               _dbConnectionCreator = new RSDatabaseConnectionCreator (_rsProfile);
               RSDatabaseNames databaseName = yyy; //  get the RSDatabaseNames 
               var useWindowsAuthentication = true; 
               var testConnection = false;
              _sqlConnection = _dbConnectionCreator.CreateConnection(databaseName,useWindowsAuthentication ,testConnection );
            }
    }

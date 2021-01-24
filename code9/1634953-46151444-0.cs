    public static class DatabaseHelper
    {
        private static OracleConnection oracleConnection;
        private static string connectionStringTemplate = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST ={0})(PORT ={1}))) (CONNECT_DATA = (SERVER = SHARED) (SERVICE_NAME = ora12c) ) ); User Id ={2}; password={3}";
        public static void SetConnection(string ipAddress, string portNumber, string userName, string password)
        {
            var connectionString = string.Format(connectionStringTemplate, ipAddress, portNumber, userName, password);
            oracleConnection = new OracleConnection(connectionString);
        }
        public static void SetConnection(string connectionString)
        {
            oracleConnection = new OracleConnection(connectionString);
        }
        public static OracleConnection GetConnection()
        {
            return oracleConnection;
        }
    }

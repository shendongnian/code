    namespace PBSM.DBGateway
    {
    public class SPService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        private static SqlConnection sqlConnection = new SqlConnection(connectionString);
        public static DataTable GetDataByStoredProcedure(string spName)
        {
            sqlConnection.Open();
            var sqlCommand = new SqlCommand(spName, sqlConnection);
            **sqlCommand.CommandType = CommandType.StoredProcedure;**
            var dataReader = sqlCommand.ExecuteReader();
            var dt = new DataTable("Command");
            dt.Load(dataReader);
            sqlConnection.Close();
            return dt;
        }
    }

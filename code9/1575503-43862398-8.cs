    public class SPService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        public static DataTable GetDataByStoredProcedure(string spName)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            using(SqlCommand sqlCommand = new SqlCommand(spName, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    var dt = new DataTable("Command");
                    dt.Load(dataReader);
                    return dt;
                 }
            }
        }
    }

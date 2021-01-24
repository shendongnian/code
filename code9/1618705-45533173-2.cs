    namespace MyDa
    {
        public class CustomerDa
        {
            public DataTable LoadData(string sqlCommandText = "")
            {
                //do your try catch finally and all the good stuff
                var connString = @"Data Source=ServerName;Initial Catalog=AdventureWorks2014;Integrated Security=SSPI;";
                var conn = new SqlConnection(connString);
                SqlDataReader dataReader;
                //you could accept the command text as a parameter
                string sql = "select top 10 * FROM [AdventureWorks2014].[HumanResources].[Department]";
                var result = new DataTable("Department");
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                dataReader = command.ExecuteReader();
                result.Load(dataReader);
                dataReader.Close();
                command.Dispose();
                conn.Close();
                //instead of a datatable, return your object
                return result;
            }
        }
    }

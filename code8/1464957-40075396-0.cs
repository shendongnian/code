    namespace Stackoverflow
    {
        public class Solution
        {
            public static object SqlExecute(
                string connectionStringName,
                string storedProcedureName,
                System
                    .Collections
                    .Generic
                    .Dictionary<string, object> parameters,
                bool isScalar)
            {
                object result = null;
    
                using (System.Data.SqlClient.SqlConnection connection =
                    new System.Data.SqlClient.SqlConnection(
                            System.
                            Configuration.
                            ConfigurationManager.
                            ConnectionStrings[connectionStringName].
                            ConnectionString))
                    if (connection != null)
                        using (System.Data.SqlClient.SqlCommand command =
                            new System.Data.SqlClient.SqlCommand()
                            {
                                CommandText = storedProcedureName,
                                CommandType = System
                                                  .Data
                                                  .CommandType
                                                  .StoredProcedure,
                                Connection = connection
                            })
                            if (command != null)
                            {
                                if (parameters != null)
                                    foreach (System
                                                 .Collections
                                                 .Generic
                                                 .KeyValuePair<string, object>
                                                     pair in parameters)
                                        command.Parameters.AddWithValue(
                                            pair.Key, pair.Value);
    
                                command.Connection.Open();
    
                                result = isScalar
                                    ? command.ExecuteScalar()
                                    : command.ExecuteNonQuery();
    
                                if (command.Connection.State ==
                                        System.Data.ConnectionState.Open)
                                    command.Connection.Close();
                            }
    
                return result;
            }
    
            public void Example()
            {
                Solution.SqlExecute(
                    @"cesConnectionString",
                    @"anyStoredProcedureName",
                    new System.Collections.Generic.Dictionary<string, object>(){
                        { @"field1", 1 },
                        { @"field2", 1.5 },
                        { @"field3", "two" },
                        { @"field4", 3.5 },
                        { @"field5", "four" },
                    },
                    false
                );
            }
        }
    }

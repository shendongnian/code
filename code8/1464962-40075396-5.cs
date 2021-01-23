    namespace Stackoverflow
    {
        public static class Solution
        {
            static readonly string _connectionStringName =
                @"mainConnectionStringName";
    
            static readonly string _connectionString =
                _connectionStringName.getConnectionString();
            // string extended method like .ToLower() or .Trim()
            public static string getConnectionString(
                this string connectionStringName)
            {
                return
                    System.
                    Configuration.
                    ConfigurationManager.
                    ConnectionStrings[connectionStringName].
                    ConnectionString;
            }
    
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
    
                using (System
                          .Data
                          .SqlClient
                          .SqlConnection connection =
                    new System.Data.SqlClient.SqlConnection(
                        string.IsNullOrWhiteSpace(connectionStringName)
                            ? _connectionString
                            : connectionStringName.getConnectionString()))
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
        }
    }
    

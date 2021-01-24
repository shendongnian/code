        public static IEnumerable<T> ExecuteQueryWithParameters<T>(string Query, string ConnectionString, string[] ParametersArray, string[] ValuesArray)
        {
            using (MySqlConnection Connection = new MySqlConnection(ConnectionString))
            {
                    for (int i = 0; i < ParametersArray.Length; i++)
                    {
                        //Replace all @Parameters
                        Query = Query.Replace(ParametersArray[i], ValuesArray[i]);
                    }
                    Connection.Open();
                    return Connection.Query<T>(Query);
            }
        }

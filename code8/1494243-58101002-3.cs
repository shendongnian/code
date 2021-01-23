        public async Task<List<T>> ExecuteReaderAsync<T>(string storedProcedureName, SqlParameter[] sqlParameters = null) where T : class, new()
        {
            var newListObject = new List<T>();
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand sqlCommand = GetSqlCommand(conn, storedProcedureName, sqlParameters);
                using (var dataReader = await sqlCommand.ExecuteReaderAsync(CommandBehavior.Default))
                {
                    if (dataReader.HasRows)
                    {
                        while (await dataReader.ReadAsync())
                        {
                            var newObject = new T();
                            dataReader.MapDataToObject(newObject);
                            newListObject.Add(newObject);
                        }
                    }
                }
            }
            return newListObject;
        }

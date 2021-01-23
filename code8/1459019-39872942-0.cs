    using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                // Query
                string query = "Query";
                DynamicParameters dp = new DynamicParameters();
                dp.Add("@userName", userName, DbType.AnsiString);
                return connection.Query<Model>(query, commandType: CommandType.StoredProcedure, param: dp);
            }

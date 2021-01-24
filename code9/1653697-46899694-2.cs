        private static void ExecuteProcedure( Dictionary<int, List<int>> dto)
        {
            string connectionString = GetConnectionString();
    
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "dbo.UserProductsInsert";
                    command.CommandType = CommandType.StoredProcedure;
    
                    SqlParameter parameter = command.Parameters.AddWithValue("@userProductsType", CreateDataTable(dto));
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.UserProductsType";
    
                    command.ExecuteNonQuery();
                }
            }
        }
   

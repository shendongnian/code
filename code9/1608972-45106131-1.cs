    private async Task<DataTable> ExecuteQueryInternalAsync(string commandText, CommandType commandType, SqlConnection sqlConnection, SqlTransaction transaction, params SqlParameter[] parameters)
            {
                using (SqlCommand cmd = new SqlCommand(commandText, sqlConnection) { CommandType = commandType, CommandTimeout = this.config.MainConnectionTimeoutInSeconds })
                {
                    if (transaction != null)
                        cmd.Transaction = transaction;
    
                    cmd.LoadParams(parameters);
    
                    if (sqlConnection.State == ConnectionState.Closed)
                        await sqlConnection.OpenAsync();
    
                    var datatable =  await cmd.ExecuteAndCreateDataTableAsync();
                    return datatable;
                }
            }

    public async Task ExecuteProcedure1Async()
    {
        using (var connection = new SqlConnection("connection string"))
        using (var command = new SqlCommand("dbo.sqlProcedure1", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            // Here execution will send request to the database
            // and be returned to the caller of this method         
            await connection.OpenAsync();
            // Continue after OpenAsync is completes and
            // Here execution will again will be returned to the caller 
            await command.ExecuteCommandAsync();
            // Continues after ExecuteCommandAsync is completed
        }      
    }

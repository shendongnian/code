    using (var conn = new SqlConnection(connectionString))
    using (var command = new SqlCommand("main.usp_setup", conn) { 
                           CommandType = CommandType.StoredProcedure }) {
       conn.Open();
       command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@file", SqlDbType.NVarChar, 1000).Value = filename;
            int rows = command.ExecuteNonQuery();
            conn.Close();
            load = true;
    }

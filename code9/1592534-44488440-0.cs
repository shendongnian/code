    using (var conn = new SqlConnection(connString)) //Connection string in there
    using (var command = new SqlCommand("ProcedureNameHere", conn) {
        CommandType = CommandType.StoredProcedure }) {
            conn.Open();
            command.ExecuteNonQuery();
    }

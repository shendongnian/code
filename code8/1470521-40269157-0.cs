    string SQLstring = @"Server=DELLXPS\SQLEXPRESS;Database=SEIN;IntegratedSecurity=true";
    string commandText = "SELECT * FROM ResidentUsers";
    using (var sqlConnection1 = new SqlConnection(SQLstring))
    using (var cmd = new SqlCommand(commandText, sqlConnection1) { CommandType = CommandType.Text })
    {
        sqlConnection1.Open();
        using (var reader = cmd.ExecuteReader())
        {
            // Data is accessible through the DataReader object here.
        }
        sqlConnection1.Close();
    }

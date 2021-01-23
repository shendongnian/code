    private void InsertRandomNumbers(int[] randomNumbers)
    {
        const string commandText = "INSERT INTO dbo.Table1 (Field1) VALUES (@field1);"
        using (var connection = new SqlConnection(connectionString)
        using (var command = new SqlCommand(commandText, connection))
        {
            var field1Parameter = new SqlDataParameter("@field1", SqlDbType.Int);
            command.Parameters.Add(field1Parameter);
            connection.Open();
            foreach (int randomNumber in randomNumbers)
            {
                field1Parameter.Value = randomNumber;
                /* int rowsAffected = */ command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    private void VoegReceptenToe()
    {
        string query = "INSERT INTO Recipe VALUES (@RecipeName, 30, 'goed mixen')";
        using (connection = new SqlConnection(connectionstring))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            connection.Open();
            command.Parameters.AddWithValue("@RecipeName", txtRecipeName.Text);
            command.ExecuteScalar();
        }
        PopulateRecipes();
    }

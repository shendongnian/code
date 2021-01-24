    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        using (SqlCommand command = new SqlCommand("SELECT SteamID FROM Details WHERE SteamID = @SteamID", connection))
        {
            command.Parameters.Add("@SteamID", SqlDbType.NVarChar).Value = SteamID;
            connection.Open();
            DisplaySQLID = command.ExecuteSalar()?.ToString() ?? "";
            connection.Close();
        }
    }

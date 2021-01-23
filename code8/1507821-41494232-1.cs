    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database2.mdf;Integrated Security=True";
    string commandText = "INSERT INTO MyTable (ID, Name, Address) VALUES (10, 'Bob', '123 Main Street');";
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(commandText, conn))
    {
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }

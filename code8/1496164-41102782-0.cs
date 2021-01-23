    using (SqlConnection connection = new SqlConnection(DBHelper.ConnectionString))
    using (SqlCommand command = new SqlCommand("Some Simple Insert Query", connection))
    {
        connection.Open();
        command.ExecuteNonQuery();
    }

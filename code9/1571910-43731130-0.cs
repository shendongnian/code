            var connectionString = ""; // Provide connecction string here.
        using (var connection = new MySqlConnection(connectionString))
        {
            MySqlCommand command = new MySqlCommand("InsertIntotblStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new MySqlParameter("PStudentId", TextBox1.Text));
            command.Parameters.Add(new MySqlParameter("PStudentName", TextBox2.Text));
            command.Connection.Open();
            var result = command.ExecuteNonQuery();
            command.Connection.Close();
        }

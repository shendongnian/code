    connection.Open();
    command = new SqlCommand(sql, connection);
    command.ExecuteNonQuery();
    command.Dispose();
    connection.Close();
    MessageBox.Show("workd ! ");

    Please use the execute non query instead of sql data adapter
        
    connection.Open();
    command = new SqlCommand(sql, connection);
    command.ExecuteNonQuery();
    command.Dispose();
    connection.Close();
    MessageBox.Show("workd ! ");

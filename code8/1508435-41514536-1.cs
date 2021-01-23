    // add the parameter first
    command.Parameters.AddWithValue("?department", cmbDepartment.Text);
    // Now execute the command. Now it has the parameter
    MySqlDataReader reader = command.ExecuteReader();
    // Now populate your combo box
    while (reader.Read())
    {
        cmbName.Items.Add(reader.GetString("name"));
    }

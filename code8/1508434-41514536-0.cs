    while (reader.Read())
    {
        command.Parameters.AddWithValue("?department", cmbDepartment.Text);
        cmbName.Items.Add(reader.GetString("name"));
    }

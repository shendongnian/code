    SqlCommand command = new SqlCommand(
          "SELECT FirstName, LastName FROM Pilots where Id = @Id;",
          connection);
    command.Parameters.AddWithValue("@Id",cmbExistingPilot.SelectedValue.ToString());
    connection.Open();
    SqlDataReader reader = command.ExecuteReader();
    if (reader.HasRows)
    {
        while (reader.Read())
        {
            txtFirstName.Text = reader.GetString(0);
            txtLastName.Text = reader.GetString(1);
            //and...
        }
    }

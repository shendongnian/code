        // Create connection object
        SqlConnection connection = new SqlConnection("ConnectionStringtoYourDB");
        SqlCommand command = connection.CreateCommand();
        try {
            // Open the connection.
            connection.Open();
            // Execute the insert command.
            command.CommandText = String.Concat("INSERT INTO Your_Tbl(FirstName) VALUES('", textBox4.Text,"')");
    
            command.ExecuteNonQuery();
            MessageBox.Show("Record Saved");
        }
     catch (Exception err)
        {
          MessageBox.Show(err.Message);
        }
        finally {
            // Close the connection.
            connection.Close();
        }

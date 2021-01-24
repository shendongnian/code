    using (SqlConnection connection = new SqlConnection("ConnectionStringHere"))
    {
    using (SqlCommand command = new SqlCommand())
    {
        command.Connection = connection;            // <== lacking
        command.CommandType = CommandType.Text;
        command.CommandText = "INSERT INTO person " +
                      "(name,lastname,phone) VALUES('@name', '@lastname', '@phone')";
        cmd.Parameters.AddWithValue("@name", txtName.Text);
        cmd.Parameters.AddWithValue("@lastname", txtLastname.Text);
        cmd.Parameters.AddWithValue("@phone", Convert.ToInt32(txtPhone.Text));
        try
        {
            connection.Open();
            int recordsAffected = command.ExecuteNonQuery();
        }
        catch(SqlException)
        {
            // error here
        }
        finally
        {
            connection.Close();
        }
    }
    }

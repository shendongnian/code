    bool UserExists = false;
    using (OleDbConnection _connection = new OleDbConnection(connection))
    {
        OleDbCommand command = new OleDbCommand("select Username from LoginTable where Username=" + Username_txtBx.Text , _connection);
        _connection.Open();
        OleDbDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            UserExists = true;
        }
        reader.Close();
    
        if (!UserExists) 
        {
            // The user does not exists - you can create it.
            command.CommandText = "insert into LoginTable(Username,[Password],[Group]) values ('" + Username_txtBx.Text + "','password'," + g + ")";
            command.ExecuteNonQuery();
        }
        else
        {
            // Show an error message - the user already exists
            MessageBox.Show("The user you eneterd already exists.");
        }
    }
    _connection.Close();

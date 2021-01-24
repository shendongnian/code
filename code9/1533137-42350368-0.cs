    Connection.Open();
    SqlCommand command = new SqlCommand(null, Connection);
    command.CommandText = "Insert into EmployeeTable (Forename,Surname,[Date of Birth], ... , ...) Values(@forename, @surname, @dateofbirth,...,...)";
    command.Parameters.AddWithValue("@forename", ForenameInputBox.Text);
    command.Parameters.AddWithValue("@surname", SurnameInputBox.Text);
    command.Parameters.AddWithValue("@dateofbirth", DoBInputBox.Text);
    ...
    ...
    command.ExecuteNonQuery();
    Connection.Close();

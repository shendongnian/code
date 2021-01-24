    string commandText = "INSERT INTO Uczniowie (ID, Name, Surname, Age) VALUES(@id, @name, @surname, @age)";
    
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@id", SqlDbType.Int);
        command.Parameters["@id"].Value = textBox1.Text;
    	...
    }

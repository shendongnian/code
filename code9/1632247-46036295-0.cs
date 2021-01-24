	var connection = new iDB2Connection(connectionString);
	connection.Open();
	var commandText = "call PROCEDURE_NAME(?)";
	var command = new iDB2Command(commandText, CommandType.Text, connection);
	iDB2CommandBuilder.DeriveParameters(command);
	command.Parameters[0].Value = "Your Parameter Value";
	iDB2DataReader reader = command.ExecuteReader();
	
	while(reader.Read())
	{
		/* Do whatever you want */
	}
	
	reader.Close();
	connection.Close();

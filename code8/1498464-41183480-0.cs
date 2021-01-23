	public static void KlantWijzigen(Klant klan)
	{
		string commandString = "UPDATE tblKlanten (Adres, Postcode, Gemeente, Email, Telefoonnummer) SET(@Adres, @Postcode, @Gemeente, @Email, @Telefoonnummer)";
		using(OleDbConnection conn = new OleDbConnection(connectionString))
		using(OleDbCommand command = new OleDbCommand())
		{
			conn.Open();
			//commandstring toevoegen aan adapter
			command.Connection = conn;
			command.CommandText = commandString;
			command.Parameters.Add("Adres", OleDbType.VarChar).Value = klan.Adres;
			command.Parameters.Add("Postcode", OleDbType.VarChar).Value = klan.Postcode;
			command.Parameters.Add("Gemeente", OleDbType.VarChar).Value = klan.Gemeente;
			command.Parameters.Add("Email", OleDbType.VarChar).Value = klan.Email;
			command.Parameters.Add("Telefoonnummer", OleDbType.VarChar).Value = klan.Telefoonnummer;
			
			OleDbDataAdapter adapter = new OleDbDataAdapter();
			adapter.UpdateCommand = command;
			//command uitvoeren
			adapter.UpdateCommand.ExecuteNonQuery();
		}
	}

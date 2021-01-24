	private void MyMethod()
	{
		UpdateValues();
	}
	
	async void UpdateValues()
	{
		using (var connection = new SqlConnection("your_connection_string_here"))
		{
			using (var command = new SqlCommand("your_sql_statement_here", connection))
			{
				connection.Open();
				command.Parameters.Add("@myParameter", SqlDbType.VarChar);
				foreach (string myValue in myValues)
				{
					command.Parameters["@myParameter"].Value = myValue;
					var dr = await command.ExecuteReaderAsync(CommandBehavior.SingleResult);
					while (dr.Read())
					{
						// do your thing here //
					}
				}
			}
		}
	}

			var connectionStringBuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();
			connectionStringBuilder.DataSource = @"c:\dev\tmp\consolidated.xlsx";
			connectionStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
			connectionStringBuilder.Add("Extended Properties", "Excel 12.0;");
			using (var connection = new System.Data.OleDb.OleDbConnection(connectionStringBuilder.ToString()))
			{
				connection.Open();
				var firstSelect = connection.CreateCommand();
				firstSelect.CommandText = "select [ID], [Language] from [first$]";
				var reader = firstSelect.ExecuteReader();
				var updateCommand = connection.CreateCommand();
				updateCommand.CommandText = "update [second$] set [Language] = ? where [ID] = ?";
				while (reader.Read())
				{
					updateCommand.Parameters.Clear();
					updateCommand.Parameters.AddWithValue("@language", reader.GetValue(1));
					updateCommand.Parameters.AddWithValue("@id", reader.GetValue(0));
					updateCommand.ExecuteNonQuery();
				}
			}

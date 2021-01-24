			var connectionStringBuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();
			connectionStringBuilder.DataSource = @"c:\dev\tmp\consolidated.xlsx";
			connectionStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
			connectionStringBuilder.Add("Extended Properties", "Excel 12.0;");
			using (var connection = new System.Data.OleDb.OleDbConnection(connectionStringBuilder.ToString()))
			{
				connection.Open();
				var updateCommand = connection.CreateCommand();
				updateCommand.CommandText = "update [second$] S inner join [first$] F on S.ID = F.ID set S.Language = F.Language";
				updateCommand.ExecuteNonQuery();
			}

	public class DataLoader_02
	{
		public int LoadData()
		{
			_infoMessage = null;
			
			using (var context = new ApplicationDbContext(@"Server=localhost\SQLEXPRESS;Database=StackOverflow;Trusted_Connection=True;"))
			{
				var sqlConnection = (SqlConnection)context.Database.Connection;
				sqlConnection.InfoMessage += InfoMessage;
				
				var cmd = context.Database.Connection.CreateCommand();
				cmd.CommandText = "[dbo].[SomeProc]";
				
				try
				{
					context.Database.Connection.Open();
					
					var reader = cmd.ExecuteReader();
					
					if (reader.FieldCount == 0)
					{
						throw new ApplicationSpecificException(_infoMessage);
					}
					
					var result = ((IObjectContextAdapter)context).ObjectContext.Translate<int>(reader);
					
					return result.First();
				}
				finally
				{
					context.Database.Connection.Close();
				}
			}
		}
			
		private void InfoMessage(object sender, SqlInfoMessageEventArgs e)
		{
			_infoMessage = e.Message;
		}
		private string _infoMessage;
	}

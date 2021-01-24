	public class DataLoader_01
	{
		public int LoadData()
		{
			_infoMessage = null;
			using (var context = new ApplicationDbContext(@"Server=localhost\SQLEXPRESS;Database=StackOverflow;Trusted_Connection=True;"))
			{
				var sqlConnection = (SqlConnection)context.Database.Connection;
				sqlConnection.InfoMessage += InfoMessage;
				try
				{
					var t = context.Database.SqlQuery<int>("EXEC ErrorMessageHandling", new object[] {});
					return t.First();
				}
				catch (EntityCommandExecutionException e)
				{
					if (string.IsNullOrEmpty(_infoMessage))
					{
						//do some error handling specific to your application
						throw new ApplicationSpecificException(_infoMessage);
					}
					throw;
				}
			}
		}
		
		private void InfoMessage(object sender, SqlInfoMessageEventArgs e)
		{
			e.Message.Dump();
			_infoMessage = e.Message;
		}
		private string _infoMessage;
	}

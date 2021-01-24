    	internal static UserModel GetUserFromApiKey(string apiKey)
		{
			using (var con = GetConnection())
			{
				using (var cmd = con.CreateCommand())
				{
					Console.WriteLine($"Key: {apiKey}");
					cmd.CommandText = $"SELECT username FROM apiKeys WHERE apikey = '{apiKey}'";
					using (var reader = cmd.ExecuteReader())
					{
						if (!reader.HasRows)
							return null;
						reader.Read();
						string username = reader.GetString(0);
						if (string.IsNullOrWhiteSpace(username))
							return null;
						else
							return new UserModel(username);
					}
				}
			}
		}

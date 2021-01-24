	public static async Task<bool> CheckUserLogin(string Username, string Password)
	{
		try
		{
			if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)) { return false; }
			if (!System.Text.RegularExpressions.Regex.IsMatch(Username, "^[a-zA-Z0-9\x20]+$")) { return false; }
			if (!System.Text.RegularExpressions.Regex.IsMatch(Password, "^[a-zA-Z0-9\x20]+$")) { return false; }
			bool UserExit = false;
			await DataBase_Connection.DB_Conn.OpenAsync();
			try
			{
				string c_query = "SELECT COUNT(*) FROM `KoN_Account` WHERE BINARY `AccountName` = @U_Name AND `HashPass` = @P_Pass LIMIT 1;";
				using (MySqlCommand CU_cmd = new MySqlCommand(c_query, db_Conn))
				{
					CU_cmd.Parameters.AddWithValue("@U_Name", Username);
					CU_cmd.Parameters.AddWithValue("@P_Pass", Password);
					var count = await CU_cmd.ExecuteScalarAsync();
					UserExit = Convert.ToBoolean(count);
				}
			}
			finally
			{
				await DataBase_Connection.DB_Conn.CloseAsync();
			}
			return UserExit;
		}
		catch (Exception ex)
		{
			LoginConsole.WriteConsoleLoginParams(System.ConsoleColor.Red, "ERROR CheckUserLogin", ex.ToString() + "\nFailed to connect to the database (server shutdown...)");
		}
		return false;
	}

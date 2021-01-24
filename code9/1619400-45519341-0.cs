	public int[] yearLogin(String username)
	{
		string sqlCmd = @"SELECT COUNT(*)
	FROM AuditActivity
	WHERE Username = @getUsername AND DateTimeActivity
	BETWEEN @getFirstDT AND @getLastDT AND ActivityType = @getType";
	
		try
		{
			Func<SqlConnection, DateTime, DateTime, int> fetch = (c, f, t) =>
			{
				using (SqlCommand cmd = new SqlCommand(sqlCmd.ToString(), c))
				{
					cmd.Parameters.AddWithValue("@getUsername", username);
					cmd.Parameters.AddWithValue("@getFirstDT", f);
					cmd.Parameters.AddWithValue("@getLastDT", t);
					cmd.Parameters.AddWithValue("@getType", "Login");
	
					return Convert.ToInt16(cmd.ExecuteScalar());
				}
			};
			using (SqlConnection myConn = new SqlConnection(DBConnectionStr))
			{
				myConn.Open();
	
				DateTime currentDT = DateTime.Today;
				DateTime FirstDT = currentDT.AddMonths(1 - currentDT.Month).AddDays(1 - currentDT.Day);
	
				int[] result =
					Enumerable
						.Range(0, 12)
						.Select(x => fetch(myConn, FirstDT.AddMonths(x), FirstDT.AddMonths(x + 1).AddTicks(-1L)))
						.ToArray();
	
				return result;
			}
		}
		catch (SqlException ex)
		{
			logManager log = new logManager();
			log.addLog("AuditNLoggingDAO.janLogin", sqlCmd.ToString(), ex);
			return null;
		}
	}

	public static IEnumerable<T> ExecuteReader<T>(string query)
	{
		try{
			return executeReader<T>(query);
		}
		catch(Exception ex){
			// your handling code here
		}
	}
	
	private static IEnumerable<T> executeReader<T>(string query)
	{
		// same code as you have above in your example
		
		using (SqlConnection cn = new SqlConnection(conn.ConnectionString))
		{
			cn.Open();
			using (SqlCommand cmd = new SqlCommand(query, cn))
			{
				using (SqlDataReader reader = cmd.ExecuteReader())
				{
				   while (reader.Read()) 
				   { 
					   yield return (T)reader[0]; 
				   }
				}
			}
		}
	}

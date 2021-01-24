	public IHttpActionResult Send()
	{    
		doAsyncOperations();
		return Ok();
	}
	private void doAsyncOperations()
	{
		using (SqlConnection con = new SqlConnection(ConnectionString))
		{
			con.Open();
			string query = @"INSERT STATEMENT";
			using (SqlCommand cmd = new SqlCommand(query, con))
			{
				cmd.ExecuteNonQuery();
			}
		}
	}

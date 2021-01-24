	public IHttpActionResult Send()
	{    
		doOperations();
		return Ok();
	}
	private void doOperations()
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

	public async Task<IHttpActionResult> Send()
	{    
		await doOperationsAsync();
		return Ok();
	}
	private async Task doOperationsAsync()
	{
		using (SqlConnection con = new SqlConnection(ConnectionString))
		{
			await con.OpenAsync();
			string query = @"INSERT STATEMENT";
			using (SqlCommand cmd = new SqlCommand(query, con))
			{
				await cmd.ExecuteNonQueryAsync();
			}
		}
	}

	public List<SalesInfo> GetSalesInfo(int userID) {
	
		using (SqlConnection conn = new SqlConnection(_connectionString))
			using (SqlCommand cmd = new SqlCommand(conn)) {
			
				cmd.CommandText = "SELECT s.* FROM ..." // insert sql statement here
                cmd.Parameters.AddWithValue("@YourUserID", userID);
				
				var adapter = new SqlDataAdapter(cmd);
				var table = new DataTable();
				
				conn.Open();
				adapter.Fill(table);
				conn.Close();
			
				var results = new List<SalesInfo>();
			
				foreach (DataRow row in table.Rows) {
					results.Add(new SalesInfo() {
					    SomeProperty = row['ColumnName'].ToString(),
						OtherProperty = int.Parse(row['OtherColumn'])
					});
				}
				
				return results;			
			}	
	}

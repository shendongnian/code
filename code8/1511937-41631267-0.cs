	public async Task<DataTable> GetDataTable(string connectionString, string cmdText)
	{
	    DataTable dt = new DataTable();
	    using (SqlConnection conn = new SqlConnection(connectionString)) {
	        using (SqlCommand comm = new SqlCommand(cmdText, conn)) {
	            conn.Open();
	            var reader=await comm.ExecuteReaderAsync();
	            dt.Load(reader);
	            return dt;
	        }
	    }
	}
	private async void Button1_Click(object sender, EventArgs e)
	{
	    try {
	        statusLabel.Text = "Processing...";
	        myDataTable = await GetDataTable(connectionString, commandText);
	        statusLabel.Text = "Done!";
	    } catch (Exception ex) {
	        MessageBox.Show("Error");
	    }
	}

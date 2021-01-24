    private async Task<DataTable> WWQuery2Run(string A, string B, string C, string D)
    {
    	try 
    	{
    		using ( var conn = new System.Data.SqlClient.SqlConnection(ReportResources.ConnString) )
    		{
    			var temp = new DataTable();
    			var DA = new SqlDataAdapter(string.Format(ReportResources.Instance.CureInfoQueries["WWQuery2"], A, B, C, D), conn);
    			await Task.Run(() => DA.Fill(temp));
    			return temp;
    		} 
    	} 
    	catch (SomeException ex)
    	{
    		// handle exception
    	}
    }

     private async Task<DataTable> WWQuery2Run
       (string A, string B, string C, string D)
      {
          using ( var conn = new System.Data.SqlClient.SqlConnection(ReportResources.ConnString) )
     {
    var temp = new DataTable();
    var DA = new SqlDataAdapter(string.Format(ReportResources.Instance.CureInfoQueries["WWQuery2"], A, B, C, D), conn);
 
	
	Task task = new Task(() => DA.Fill(temp));
     try
    {
        task.Wait();
    }
    catch (Exception ae)
    {
        
    }
    return temp;
    }
    }  

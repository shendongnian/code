    string connectionString = "your connection string";
    int id = 1;
    SqlConnection conn = new SqlConnection(connectionString);
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;
    cmd.CommandText = "SELECT [ExcelData] FROM [SavedFiles] WHERE ID = @ID";
    cmd.Parameters.AddWithValue("@ID", id);
    SqlDataReader dr = cmd.ExecuteReader();
    
    if (dr.Read())
    {
    	byte[] bytes = (byte[])dr["ExcelData"];
    	Response.Buffer = true;
    	Response.Charset = "";
    	Response.AddHeader("content-disposition", @"attachment;filename=""file.xlsx""");
    	Response.Cache.SetCacheability(HttpCacheability.NoCache);
    	Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    	Response.BinaryWrite(bytes);
    	Response.End();
    }

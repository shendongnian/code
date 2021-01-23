    using (SqlConnection conn = new SqlConnection(GetConnectionString()))
    using (SqlCommand cmd = new SqlCommand("SELECT BatchCode, BatchCodeDesc FROM BatchTable", conn))
    {
    	try
    	{
    		conn.Open();
    		DataTable batch_codes = new DataTable();
    		dt.Load(cmd.ExecuteReader());
    		ddlBatchCodeDel.DataSource = batch_codes;
    		ddlBatchCodeDel.DataTextField = "BatchCodeDesc";
    		ddlBatchCodeDel.DataValueField = "BatchCode";
    		ddlBatchCodeDel.DataBind();
    	}
    	catch (Exception ex)
    	{
    		Response.Write(ex.Message);
    	}
    }

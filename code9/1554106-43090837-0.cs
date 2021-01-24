    public override bool SaveUserQueryAttachment(List<UserQueryAttachmentToCreate> fileList)
    {
    	// TODO: open a SQL connection here 
    	
    	using (SqlCommand cmd = new SqlCommand("exec PROC_UserQueryAttachment_Insert @table", connection))
    	{
    		using (var table = new DataTable()) 
    		{
    			table.Columns.Add("UserQueryId", typeof(string));
    			table.Columns.Add("AttachmentPath", typeof(string));
    			table.Columns.Add("AttachmentName", typeof(string));
    			table.Columns.Add("AttachmentFor", typeof(string));
    			table.Columns.Add("CreatedBy", typeof(string));
    
    			table.Rows.Add(fileList.ToArray());
    
    			var list = new SqlParameter("@table", SqlDbType.Structured);
    			list.TypeName = "dbo.UserQueryAttachmentList";
    			list.Value = table;
    
    			cmd.Parameters.Add(list);
    			cmd.ExecuteReader();
    		 }
    	}
    	
    	// TODO: close the SQL connection
    }

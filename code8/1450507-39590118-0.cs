    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
    	if (e.Item is GridDataItem)
            {
                    GridDataItem item = e.Item as GridDataItem;
                    RadButton btnReject = item.FindControl("btnReject") as RadButton; 
                    
                    if (item.GetDataKeyValue("IsCancelled").ToString() == "1")
                    {
                        btnReject.Enabled = true;
                    }
    		else
    		{
                        btnReject.Enabled = false;	
    		}
      
    	}
    }

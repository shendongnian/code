    public void ddlBatchCodeDelBind()
    {
    	var x = new Dictionary<int, string>();
    	x.Add(1, "Data 1");
    	x.Add(2, "Data 2");
    	x.Add(3, "Data 3");
    	
    	ddlBatchCodeDel.DataSource = X;
    	ddlBatchCodeDel.DataTextField = "Value";
    	ddlBatchCodeDel.DataValueField = "Key";
    	ddlBatchCodeDel.DataBind();
    }

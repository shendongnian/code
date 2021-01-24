    protected void Page_PreRender(object sender,EventArgs e)
    {
    	if (IsPostBack)
    	{
    		Response.Write(ViewState["Value"].ToString());
    	}
    }

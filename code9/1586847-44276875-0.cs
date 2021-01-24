    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	if(e.CommandName.ToString() == "view")
    	{
    		Response.Redirect("~/redirect.aspx?view=" + e.CommandArgument);
    	}
    }

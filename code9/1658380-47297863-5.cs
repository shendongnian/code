    protected void rgEffectivePermissions_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
    	if(e.CommandName == "MyCommand")
    	{
    		rgSecurityGroup.DataSource = GetGridSource(int.Parse(e.CommandArgument.ToString()));
    		rgSecurityGroup.Rebind();
    	}
    }

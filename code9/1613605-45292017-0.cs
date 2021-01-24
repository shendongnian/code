    DataTable table;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //We query the DB only once in the Page Load
        string sSQL = "Select stateID, sateName from Mytable ORDER By stateName ASC";
        SqlCommand cmd6 = new SqlCommand(sSQL, con);
        con.Open();
        table = new DataTable();
        table.Load(cmd6.ExecuteReader());
        
    }
    //We load the DropDownList in the event
    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		var ddl = (DropDownList)e.Item.FindControl("ddlID");
		ddl.DataSource = table;
        ddl.DataTextField = "stateName";
        ddl.DataValueField = "stateID";
        ddl.DataBind();
	}

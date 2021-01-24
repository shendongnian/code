    protected void Page_Load(object sender, System.EventArgs e)
    {
        DataTable dt = GetDataTable("select * from AccountTypes");
    
        repeater.DataSource = dt;
        repeater.DataBind();
    }
    
    private void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item) {
            return;
        }
    
        var row = e.Item.DataItem;
    }

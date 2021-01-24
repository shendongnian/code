    protected void parent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        // check Repeater item type is not in edit mode
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater childRepeater = e.Item.FindControl("childrepeater") as Repeater;
            childRepeater.DataSource = "Get Your Datasource here";
            childRepeater.DataBind();  
        }
    }

    protected void rptrProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var addItem = e.Item.FindControl("addItem") as Button;
            addItem.Visible = Convert.ToBoolean(Session["SomeValue"]);
        }
    }

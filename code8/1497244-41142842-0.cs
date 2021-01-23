    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var repeater2 = (Repeater)e.Item.FindControl("Repeater2");
            //now you can bind etc to repeater2
        }
    }

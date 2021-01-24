    protected void CustomerRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DropDownList ds = (DropDownList)e.Item.FindControl("dropdown1");
                ds.Items.Add((e.Item.FindControl("lblOrderID") as Label).Text);
            }
        }

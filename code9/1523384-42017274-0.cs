    void contactsListRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var item = e.Item;
        if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
        {
            var anchor = item.FindControl("anchor") as HtmlAnchor;
            anchor.ServerClick += contactLink_Click;
        }
    }

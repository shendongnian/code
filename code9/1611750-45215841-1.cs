    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var stringInstrumentItem = e.Item.DataItem as stringInstrumentItem;
    
            Image img = e.Item.FindControl("brandImage") as Image;
            img.ImageUrl = string.Format("~/Images/Guitar Brands/Guitar Items/{0}", stringInstrumentItem.brand.image);
        }
    }

     if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        { 
    ImageButton img = (ImageButton)e.Item.FindControl("brandImage");
     image.Attributes.Add("onmouseover","this.style.backgroundColor=\"blue\"");
    }

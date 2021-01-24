    protected void dtlViewUser_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        // This event is raised for the header, the footer, separators, and items.
        // Execute the following logic for Items and Alternating Items.
        if (e.Item.ItemType == ListItemType.Item || 
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string imgupdated = "<img id=\"imgupdated\" src=\"Images/active.png\"  alt=\"updated\" />";
            ((Label)e.Item.FindControl("lblImage")).Text = imgupdated;
        }
    }

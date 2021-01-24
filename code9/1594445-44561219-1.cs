    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Gather currently selected items
        List<ListItem> newSelectedItems = new List<ListItem>();
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected == true) 
            {
                newSelectedItems.Add(item);
            }
        }
        
        List<ListItem> oldSelectedItems = Session["SelectedItems"] as List<ListItem>;
        // Compare previous items count with current items count 
        // to find out whether item has been selected or deselected
        if (newSelectedItems.Count > oldSelectedItems.Count)
        {
            // Item has been selected
            ListItem selectedItem = newSelectedItems.Except(oldSelectedItems).First();
        }
        else
        {
            // Item has been deselected
            ListItem deselectedItem = oldSelectedItems.Except(newSelectedItems).First();
        }
        Session["SelectedItems"] = newSelectedItems;
    }

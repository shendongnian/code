    foreach (DataListItem item in datalist1.Items)
    {
       if (item.ItemType == ListItemType.Footer)
       {
           Label lbl = (Label)item.FindControl("Label1");
       }
    }

    foreach (DataListItem item in dtaddedOrderItem.Items)
    {
        DataList dtaddedsubserviceitem = (DataList)item.FindControl("dtaddedsubserviceitem");
        foreach(Control control in dtaddedsubserviceitem.Controls)
        {
            DataListItem item = (DataListItem)control;
            if (item.ItemType == ListItemType.Footer)
            {
                DataList dtsuggestedlist = (DataList)footer.FindControl("dtsuggestedlist");
                if(dtsuggestedlist != null)
                {
                    // do your code here
                }
            }
        }
    }

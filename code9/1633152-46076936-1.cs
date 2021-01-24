        int numSelected = 0;
        string sEmail = string.Empty;
        foreach (ListItem item in myListItem.Items)
        {
            if (item.Selected)
            {
                numSelected = numSelected + 1;
                if (numSelected > 1)
                {
                    //Alert for items selected are more than 1
                }
                else
                {
                    sEmail += item.Value + "; ";
                }
            }
        }

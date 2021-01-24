    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
            List<ListItem> SelectedItems = new List<ListItem>();
            foreach (ListItem ItemsSelected in CheckBoxList1.Items)
            {
                if (ItemsSelected.Selected)
                    SelectedItems.Add(ItemsSelected);
            }
            if(SelectedItems.Count() == 5)
            {
                // Display alert
                foreach(ListItem item in CheckBoxList1.Items)
                {
                    if(!SelectedItems.Contains(item))
                    {
                        item.Enabled = false;
                    }
                }
            } else
            {
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    item.Enabled = true;
                }
            }
    }

    private void lstServices_ItemChecked(Object sender, ItemCheckedEventArgs e)
    {
         ListViewItem item=e.Item;
         if (item.Checked)
         {
             item.Group = lstServices.Groups[1];
         }
         else
         {
             item.Group = lstServices.Groups[0];
         }
    }
    

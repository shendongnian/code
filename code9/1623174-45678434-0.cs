    private static void MoveSelectedItems(ListView source, ListView target)
    {
        if(source.SelectedItems.Count > 0)
        {
            ListViewItem selectedItem= source.SelectedItems[0];
            foreach (var subItem in source.SelectedItems[0].SubItems)
            {
                 selectedItem.SubItems.Add (subItem);
            }
            source.Items.Remove(selectedItem);
            target.Items.Add(selectedItem);
        }
    }

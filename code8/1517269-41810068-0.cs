    foreach (var item in osebe_listView.Items)
    {
        if (o == item)
        {
            ListViewItem lvi = osebe_listView.ItemContainerGenerator.ContainerFromItem(item) as ListViewItem;
            if(lvi != null)
                lvi.Visibility = Visibility.Collapsed;
            count++;
        }
    }

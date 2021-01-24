    private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        TreeItem temp = treeView.SelectedItem as TreeItem;
        if (temp != null)
        {
            ClientListEntry clientListEntry = temp.Data as ClientListEntry;
            if (clientListEntry != null)
            {
                //Data is a ClientListEntry
                //...
                return;
            }
            Channel channel = temp.Data as ClientListEntry;
            if (channel != null)
            {
                //...
            }
        }
        MessageBox.Show(temp.ToString());
    }

    private void DeleteListItem(object sender, RoutedEventArgs e)
    {
      var curItem = ((ListBoxItem)listView.ContainerFromElement((Button)sender));
      listView.SelectedItem = (ListBoxItem)curItem;
      MessageBox.Show($"Selected index = {listView.SelectedIndex}");
    
      // Add code for delete item here
    }

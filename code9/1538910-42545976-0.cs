     private void listViewDirectory_SelectionChanged(object sender, SelectionChangedEventArgs e)
     {        
         var container = AllDevicesGridView.ContainerFromItem(AllDevicesGridView.SelectedItem);
         GridViewItem item = container as GridViewItem;
         System.Diagnostics.Debug.WriteLine(item.ActualHeight);
     }

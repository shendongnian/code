    foreach (ListViewItem item in osebe_listView.Items)
    {
      if ((item.DataContext as Oseba) != null)
      {
          item.Visibility = Visibility.Collapsed;
      }
    }

    foreach (ListViewItem item in osebe_listView.Items)
    {
      if ((o.DataContext as Oseba) != null)
      {
          item.Visibility = Visibility.Collapsed;
      }
    }

    //If the sum of all column widths > ListView width -> enable scrollbar.
    foreach (var column in gridView.Columns)
    {
      ((INotifyPropertyChanged)column).PropertyChanged += (sender, e) =>
      {
        if (e.PropertyName == "ActualWidth")
        {
          var totalColumnWidth = gridView.Columns.Sum(col => col.ActualWidth);
          var listViewWidth = listView.ActualWidth;
          if (totalColumnWidth > listViewWidth)
            listView.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Auto);
          else
            listView.SetValue(ScrollViewer.HorizontalScrollBarVisibilityProperty, ScrollBarVisibility.Disabled);
        }
      };
    } 

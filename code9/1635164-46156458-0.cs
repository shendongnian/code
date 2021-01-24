    private void ColumnSeries_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ColumnSeries cs = sender as ColumnSeries;
        IEnumerable<ColumnDataPoint> columns = FindVisualChildren<ColumnDataPoint>(cs);
        foreach (var column in columns)
        {
            if (column.DataContext == e.AddedItems[0]) //change the background of the selected one
            {
                column.Background = Brushes.DarkBlue;
                break;
            }
        }
    }
    private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            int NbChild = VisualTreeHelper.GetChildrenCount(depObj);
            for (int i = 0; i < NbChild; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
                foreach (T childNiv2 in FindVisualChildren<T>(child))
                {
                    yield return childNiv2;
                }
            }
        }
    }

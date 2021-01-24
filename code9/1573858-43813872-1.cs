    private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
    {
        var h = e.OriginalSource as GridViewColumnHeader;
        if (h != null)
        {
            var propertyName = h.Column.GetValue(TextSearch.TextPathProperty) as string;
            var cvs = ListViewAnlagen.ItemsSource as ICollectionView ??
                CollectionViewSource.GetDefaultView(ListViewAnlagen.ItemsSource) ??
                ListViewAnlagen.Items;
            if (cvs != null)
            {
                cvs.SortDescriptions.Clear();
                cvs.SortDescriptions.Add(new SortDescription(propertyName, ListSortDirection.Descending));
            }
        }
    }

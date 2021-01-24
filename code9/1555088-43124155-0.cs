    if (DataGrid.ItemsSource != null)
    {
        //This is the line that your are missing
        var myViewSource = DataGrid.ItemsSource as CollectionViewSource;
        myViewSource.SortDescriptions.Add(new SortDescription("Column2", ListSortDirection.Ascending));
        myViewSource.SortDescriptions.Add(new SortDescription("Column3", ListSortDirection.Descending));
        myViewSource.SortDescriptions.Add(new SortDescription("Column4", ListSortDirection.Descending));
    }

    if (DataGrid.ItemsSource != null)
    {
        //This is the line that your are missing
        var myViewSource = DataGrid.ItemsSource as CollectionViewSource;
        myViewSource.SortDescriptions.Add(new SortDescription("AgentState", ListSortDirection.Ascending));
        myViewSource.SortDescriptions.Add(new SortDescription("AuxReasons", ListSortDirection.Descending));
        myViewSource.SortDescriptions.Add(new SortDescription("AgentDateTimeStateChange", ListSortDirection.Descending));
    }

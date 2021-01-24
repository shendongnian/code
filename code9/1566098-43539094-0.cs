    private void Person_Sorting(object sender, DataGridSortingEventArgs e)
    {
        e.Column.SortDirection = System.ComponentModel.ListSortDirection.Ascending;
    }
----------
    <DataGrid Name="Person" ItemsSource="{Binding PersonList}" Sorting="Person_Sorting" ...>

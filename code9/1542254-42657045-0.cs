    <DataGrid x:Name="dataGrid">
        <DataGrid.RowStyle>
            <Style TargetType="DataGridRow">
                <EventSetter Event="Loaded" Handler="RowLoaded" />
            </Style>
        </DataGrid.RowStyle>
    </DataGrid>
----------
    private void RowLoaded(object sender, RoutedEventArgs)
    {
        DataGridRow dgr = sender as DataGridRow;
        MyDataObject x = dgr.DataContext as MyDataObject;
        if (x.TotalCost == dataGrid.Items.OfType<MyDataObject>().Min(y => y.TotalCost))
            dgr.Background = Brushes.Green;
    }

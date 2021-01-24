    <DataGrid Loaded="DataGrid_Loaded">
        <DataGrid.Columns>
            <DataGridTemplateColumn x:Name="col1" Header="Col1">
            ...
        </DataGrid.Columns>
    </DataGrid>
----------
    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        BindingOperations.SetBinding(col1, DataGridColumn.DisplayIndexProperty,
            new Binding("CarID") { Source = this, Converter = new FieldNameToIndex(), FallbackValue = 0 });
    }

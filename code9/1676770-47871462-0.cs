    <StackPanel Orientation="Vertical" x:Name="DataGridContainer"
                DataGrid.SelectionChanged="DataGridContainer_SelectionChanged"
                xmlns:s="clr-namespace:System;assembly=mscorlib">
        <DataGrid>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding}" />
            </DataGrid.Columns>
            <s:String>A</s:String>
            <s:String>A</s:String>
            <s:String>A</s:String>
        </DataGrid>
        <DataGrid>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding}" />
            </DataGrid.Columns>
            <s:String>B</s:String>
            <s:String>B</s:String>
            <s:String>B</s:String>
        </DataGrid>
        <DataGrid>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding}" />
            </DataGrid.Columns>
            <s:String>C</s:String>
            <s:String>C</s:String>
            <s:String>C</s:String>
        </DataGrid>
    </StackPanel>
----------
    private bool _handle = true;
    private void DataGridContainer_SelectionChanged(object sender, RoutedEventArgs e)
    {
        if (_handle)
        {
            var datagrid = e.OriginalSource as DataGrid;
            if (datagrid != null)
            {
                var datagridList = DataGridContainer.Children.OfType<DataGrid>();
                foreach (var dt in datagridList)
                {
                    if (dt != datagrid)
                    {
                        _handle = false;
                        dt.UnselectAll();
                        _handle = true;
                    }
                }
            }
        }
    }

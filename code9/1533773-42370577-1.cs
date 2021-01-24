    <DataGrid x:Name="dg" Loaded="dg_Loaded">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding}" />
            <DataGridTextColumn Binding="{Binding}" Header="short" />
        </DataGrid.Columns>
    </DataGrid>
----------
    private void dg_Loaded(object sender, RoutedEventArgs e)
    {
        dg.Columns[0].Width = new DataGridLength(dg.Columns[0].ActualWidth);
        dg.Columns[0].Header = "some very long header some very long header  some very long header";
    }

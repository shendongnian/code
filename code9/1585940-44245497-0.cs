    <DataGrid x:Name="dg" SelectionUnit="FullRow">
        <DataGrid.RowStyle>
            <Style TargetType="DataGridRow">
                <EventSetter Event="PreviewMouseLeftButtonDown" Handler="dg_PreviewMouseLeftButtonDown" />
            </Style>
        </DataGrid.RowStyle>
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding}" />
            <DataGridTextColumn Binding="{Binding}">
                <DataGridTextColumn.CellStyle>
                    <Style TargetType="DataGridCell">
                        <Setter Property="IsEnabled" Value="False" />
                    </Style>
                </DataGridTextColumn.CellStyle>
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
----------
    private void dg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DataGridRow row = sender as DataGridRow;
        dg.SelectedItem = row.DataContext;
    }

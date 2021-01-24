    <DataGrid x:Name="dtgTarafDovvom" Style="{StaticResource DataGridStyle1}" ItemsSource="{Binding}">
        <DataGrid.RowStyle>
            <Style TargetType="DataGridRow">
                <EventSetter Event="MouseDoubleClick" Handler="dtgTarafDovvom_MouseDoubleClick" />
            </Style>
        </DataGrid.RowStyle>
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Path=TarafeynQarardadID}" Header="کد " />
        </DataGrid.Columns>
    </DataGrid>
----------
    private void dtgTarafAvval_MouseDoubleClick(object sender, ouseButtonEventArgs e)
    {
        DataGridRow row = sender as DataGridRow;
        TarafeynQarardadDTO t = row.DataContext as TarafeynQarardadDTO;
        int tarafeynID = t.TarafeynQarardadID;
    }

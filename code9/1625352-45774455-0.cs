    <DataGrid AutoGeneratingColumn="DataGrid_OnAutoGeneratingColumn">
    </DataGrid>
<!---->
    // fixing checkboxes in DataGrid DataGridCheckBoxColumns
    private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        var column = e.Column as DataGridCheckBoxColumn;
        if (column == null)
            return;
        var dg = sender as DataGrid;
        if (dg == null)
            return;
        column.ElementStyle = (Style)dg.FindResource("DateChk");
        column.EditingElementStyle = (Style)dg.FindResource("DateChk");
    }

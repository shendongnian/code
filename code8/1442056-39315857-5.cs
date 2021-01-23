    private void dataGrid_AutoGeneratingColumn(object sender,
        DataGridAutoGeneratingColumnEventArgs e)
    {
        DataGrid grid = sender as DataGrid;
        // Only DataGridCheckBoxColumns
        if (e.PropertyType == typeof(bool))
            e.Column.HeaderStyle =
                (Style)grid.FindResource("CheckBoxColumnHeaderStyle");
    }

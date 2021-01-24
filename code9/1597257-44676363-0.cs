    private void grd_Cells_Selected(object sender, RoutedEventArgs e) {
        int col = PNTable.SelectedCells[0].Column.DisplayIndex;
        if (col <= 2) {
            if (e.OriginalSource.GetType() == typeof(DataGridCell)) {
                // Starts the Edit on the row;
                DataGrid grd = (DataGrid)sender;
                grd.BeginEdit(e);
            }
        }
    }

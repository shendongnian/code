    private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        DataGrid myGrid = (DataGrid)sender; // now this is strongly typed so we can drill into its properties.
    
        var selectedCells = myGrid.SelectedCells; // there can be more than one cell selected!  Which column is that in?
        if (selectedCells.Count > 0)
        {
            DataGridCellInfo firstSelectedCell = selectedCells[0]; // usually there will be only one selected.  If not, think about how you want to handle this.
            DataGridColumn ignoreThisColumn = myGrid.Columns[1]; // whichever column you want to ignore - you could also have several columns in an array...
    
            if (firstSelectedCell.Column != ignoreThisColumn)
            {
                // do your logic here - we know they clicked on some other column...
            }
        }
    }

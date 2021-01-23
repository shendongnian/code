    void exporter_CellFormatting(object sender, Telerik.WinControls.Export.CellFormattingEventArgs e)
        {
            if (e.GridColumnIndex == 2 && e.GridRowIndex >-1)
            {
                string newValue = (bool)e.GridCellInfo.Value ? "YES" : "NO";
                Telerik.Windows.Documents.Spreadsheet.Model.CellSelection excelCell = (Telerik.Windows.Documents.Spreadsheet.Model.CellSelection)e.CellSelection;
                excelCell.SetValue(newValue);
            }
        }

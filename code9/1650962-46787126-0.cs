    StringBuilder sb = new StringBuilder();
    foreach(var selectedRow in DataGrid_Table.SelectedItems.OfType<DataRowView>())
    {
        foreach(DataColumn column in selectedRow.DataView.Table.Columns)
        {
            sb.Append(selectedRow[column.ColumnName] + ";");
        }
        sb.Append(Environment.NewLine);
    }
    string export = sb.ToString();

    private void DG_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {                        
       DataGridTextColumn textColumn = new DataGridTextColumn();
       textColumn.Header = e.Column.Header;
       textColumn.Binding = new Binding(e.Column.Header.ToString());
       textColumn.CellStyle = new Style();
       textColumn.CellStyle.TargetType = typeof(DataGridCell);
       textColumn.CellStyle.Setters.Add(new Setter(DataGridCell.BackgroundProperty, new Binding(e.Column.Header + ".Background")));
       (sender as DataGrid).Columns.Add(textColumn);
       // Prevent autogenerating the columns
       e.Cancel = true;
    }

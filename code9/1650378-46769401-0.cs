    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        DataGridTextColumn col = e.Column as DataGridTextColumn;
        if (col != null && e.PropertyType == typeof(double))
        {
            col.Binding = new Binding(e.PropertyName) { StringFormat = "F2" };
        }
    }

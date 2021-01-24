    private void datagrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        DataGridTextColumn col = e.Column as DataGridTextColumn;
        if (col != null && e.PropertyType == typeof(double))
        {
            if (!col.Header.ToString() == "Amount")
                col.Binding = new Binding(e.PropertyName) { StringFormat = "N0" };
            else
                col.Binding = new Binding(e.PropertyName) { StringFormat = "N2" };
        }
    }

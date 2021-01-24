    private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "YourColumnName")
        {
            e.Column.IsReadOnly = true;
        }
    }

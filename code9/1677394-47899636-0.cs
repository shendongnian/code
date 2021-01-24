    private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "Name")
        {
            e.Column.Header = new CheckBox { Content = "Check all" };
        }
    }

    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
    buttonColumn.Name = "YourColumn";
    buttonColumn.Text = "YourText";
    if (YourDataGrid.Columns["YourColumn"] == null)
    {
        YourDataGrid.Columns.Insert(4, buttonColumn); //here you have to put the columnIndex
    }

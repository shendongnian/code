    <DataGrid Name="DGHolder" ... AutoGeneratingColumn="dg_AutoGeneratingColumn">
----------
    private void dg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if (e.PropertyName == "ID")
        {
            e.Column = new DataGridHyperlinkColumn()
            {
                ContentBinding = new Binding(e.PropertyName),
            };
        }
    }

    this.dataGrid.Columns.Add(
        new DataGridTextColumn
        { Header = "c1", Binding = new Binding("c1") } );
    
    this.dataGrid.Columns.Add(
        new DataGridTextColumn
        { Header = "c2", Binding = new Binding("c2") });
    this.dataGrid.LoadingRow += DataGrid_LoadingRow;
             
    foreach (Ro me in data)
    {
        dataGrid.Items.Add(me);
    }

    public void AddColumn()
    {
        this.Table.Columns.Add("ColumnTest");
        dgdMain.Columns.Add(new DataGridTextColumn() { Binding = new Binding("ColumnTest"), Header = "ColumnTest" });
    }

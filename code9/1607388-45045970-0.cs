    protected void Page_Load(object sender, EventArgs e)
    {
        LiteralControl ltr = new LiteralControl();
        ltr.Text = "<style type=\"text/css\" rel=\"stylesheet\">" + @".fl { float: left}</style>";
        Page.Header.Controls.Add(ltr);
    
        for(int i = 0; i < 6; i++)
        {
            Table table = CreateTable();
            PlaceHolderTables.Controls.Add(table);
        }
    }
    
    private Table CreateTable()
    {
        TableCell cell = new TableCell();
        cell.Controls.Add(new Literal { Text = "Hello!"});
    
        TableRow row = new TableRow();
        row.Cells.Add(cell);
    
        Table table = new Table();
        table.Rows.Add(row);
        return table;
    }

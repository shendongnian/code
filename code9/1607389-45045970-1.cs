    protected void Page_Load(object sender, EventArgs e)
    {
        LiteralControl ltr = new LiteralControl();
        ltr.Text = "<style type=\"text/css\" rel=\"stylesheet\">" + @".fl { float: left}</style>";
        Page.Header.Controls.Add(ltr);
    
        Table main = new Table();
        for (int i = 0; i < 6; i++)
        {
            TableRow row = new TableRow();
            for (int j = 0; j < 6; j++)
            {
                Table table = CreateTable($"{i}x{j}");
                TableCell cell = new TableCell();
                cell.Controls.Add(table);
                row.Controls.Add(cell);
            }
            main.Controls.Add(row);
        }
        PlaceHolderTables.Controls.Add(main);
    }
    
    private Table CreateTable(string text)
    {
        TableCell cell = new TableCell();
        cell.Controls.Add(new Literal {Text = text });
    
        TableRow row = new TableRow();
        row.Cells.Add(cell);
    
        Table table = new Table();
        table.Rows.Add(row);
        return table;
    }

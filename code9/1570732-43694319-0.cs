    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //not here
        }
        //but here
        TableRow row = new TableRow();
        TableCell cell1 = new TableCell();
        TableCell cell2 = new TableCell();
        TableCell cell3 = new TableCell();
        TableCell cell4 = new TableCell();
        cell1.Text = 1.ToString();
        cell1.Text = 2.ToString();
        cell1.Text = 3.ToString();
        cell1.Text = 4.ToString();
        row.Cells.Add(cell1);
        row.Cells.Add(cell2);
        row.Cells.Add(cell3);
        row.Cells.Add(cell4);
        lastRecordTable.Rows.Add(row);
    }

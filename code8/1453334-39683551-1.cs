    protected void OnDataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "New";
        cell.ColumnSpan = 4;
        row.Controls.Add(cell);
        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Old";
        row.Controls.Add(cell);
        GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
    }

    protected void btn1_Click(object sender, EventArgs e)
    {
        GridViewRow row1 = GridView1.Rows[0];
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
        for (int i = 0; i < row1.Cells.Count; i++)
        {
            TableCell cell = new TableCell();
            cell.Text = "&nbsp;";
            row.Cells.Add(cell);
            Table parentTable = row1.Parent as Table;
            parentTable.Rows.Add(row);
        }
    }

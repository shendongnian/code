    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //header
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //add 6 cells
            for (int i = 1; i <= 6; i++)
            {
                TableHeaderCell headerCell = new TableHeaderCell();
                if (i == 6)
                {
                    headerCell.Text = "URL";
                }
                else
                {
                    headerCell.Text = "Static " + i;
                }
                //add the new cell to the gridview
                e.Row.Cells.AddAt(i, headerCell);
            }
        }
        //normal row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the current row to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            //add 6 cells
            for (int i = 1; i <= 6; i++)
            {
                TableCell cell = new TableCell();
                if (i == 6)
                {
                    cell.Text = string.Format("<a target=\"_blank\" href=\"{0}\">{0}</a>", row["myURL"]);
                }
                else
                {
                    cell.Text = "Enter stuff here...";
                }
                //add the new cell to the gridview
                e.Row.Cells.AddAt(i, cell);
            }
        }
    }

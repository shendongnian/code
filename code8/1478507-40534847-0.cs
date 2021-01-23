    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            int spanColumn_1_start = 2;
            int spanColumn_1_length = 2;
            //apply colspan
            e.Row.Cells[spanColumn_1_start].ColumnSpan = spanColumn_1_length;
            //remove the spanned cells
            for (int i = 1; i < spanColumn_1_length; i++)
            {
                e.Row.Cells.RemoveAt(spanColumn_1_start + 1);
            }
            //note that the startindex of the 2nd colspan is set after removing cells for 1st colspan
            int spanColumn_2_start = 3;
            int spanColumn_2_length = 2;
            //apply colspan
            e.Row.Cells[spanColumn_2_start].ColumnSpan = spanColumn_2_length;
            //remove the spanned cells
            for (int i = 1; i < spanColumn_2_length; i++)
            {
                e.Row.Cells.RemoveAt(spanColumn_2_start + 1);
            }
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //to add a row above the normal gridview header, use: if (e.Row.RowType == DataControlRowType.Header)
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItemIndex == 0)
        {
            //cast the sender as gridview
            GridView gridView = sender as GridView;
            //create a new gridviewrow
            GridViewRow gridViewRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //add some cells
            TableCell tableCell = new TableCell();
            tableCell.Text = "";
            tableCell.ColumnSpan = 2;
            gridViewRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "AM";
            gridViewRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "PM";
            gridViewRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "AM";
            gridViewRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            tableCell.Text = "PM";
            gridViewRow.Cells.Add(tableCell);
            //add the new row to the gridview
            gridView.Controls[0].Controls.AddAt(1, gridViewRow);
        }
    }

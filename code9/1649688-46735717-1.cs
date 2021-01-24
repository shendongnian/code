    int rowIndex = 0;
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //the amount of rows in between the inserted rows
        int rowsInBetween = 3;
        //check if the row is a datarow
        if (e.Row.RowType == DataControlRowType.DataRow && rowIndex % (rowsInBetween + 1) == 0 && rowIndex > 0)
        {
            //create a new row
            GridViewRow extraRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
            extraRow.BackColor = Color.Green;
            //add one cell with text
            TableCell cell1 = new TableCell();
            cell1.Text = "ExtraRow";
            extraRow.Cells.Add(cell1);
            //add another one with a textbox and column spanning
            TableCell cell2 = new TableCell();
            cell2.ColumnSpan = GridView1.Columns.Count - 1;
            TextBox tb1 = new TextBox();
            tb1.Text = "Inserted TextBox";
            cell2.Controls.Add(tb1);
            extraRow.Cells.Add(cell2);
            //add the new row to the gridview
            GridView1.Controls[0].Controls.AddAt(rowIndex, extraRow);
            //extra increment the row count
            rowIndex++;
        }
        rowIndex++;
    }

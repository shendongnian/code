    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //cast the sender back to a gridview
        GridView gv = sender as GridView;
        //check if the row is the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //create a new row
            GridViewRow extraHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            extraHeader.BackColor = Color.Red;
            //loop all the columns and create a new cell for each
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                TableCell cell = new TableCell();
                cell.Text = "ExtraHeader " + i;
                //add the cell to the new header row
                extraHeader.Cells.Add(cell);
            }
            //add the new row to the gridview
            gv.Controls[0].Controls.AddAt(0, extraHeader);
        }
        //check if the row is the footer row
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //create a new row
            GridViewRow extraFooter = new GridViewRow(0, 0, DataControlRowType.Footer, DataControlRowState.Insert);
            extraFooter.BackColor = Color.Green;
            //add one cell with colspan 2
            TableCell cell1 = new TableCell();
            cell1.Text = "ExtraFooter 1";
            cell1.ColumnSpan = 2;
            extraFooter.Cells.Add(cell1);
            //add another one with colspanning the rest 
            TableCell cell2 = new TableCell();
            cell2.Text = "ExtraFooter 2";
            cell2.ColumnSpan = gv.Columns.Count - 2;
            extraFooter.Cells.Add(cell2);
            //add +2 to the row count. one for the extra header and 1 for the extra footer
            int insertIndex = gv.Rows.Count + 2;
            //add the new row to the gridview
            gv.Controls[0].Controls.AddAt(insertIndex, extraFooter);
        }
    }

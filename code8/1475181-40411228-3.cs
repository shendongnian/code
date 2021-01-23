    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //cast the sender back to a gridview
        GridView gv = sender as GridView;
        //check if the row is the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //create a new row
            GridViewRow extraHeader = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            extraHeader.BackColor = Color.Green;
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
    }

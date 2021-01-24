    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //cast the sender back to a gridview
        GridView gv = sender as GridView;
        //check if the row is the header row
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //create the first row
            GridViewRow extraHeader1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            extraHeader1.BackColor = Color.LightSalmon;
            TableCell cell1 = new TableCell();
            cell1.ColumnSpan = 2;
            cell1.Text = "General";
            extraHeader1.Cells.Add(cell1);
            TableCell cell2 = new TableCell();
            cell2.ColumnSpan = 3;
            cell2.Text = "Totals";
            extraHeader1.Cells.Add(cell2);
            //create the second row
            GridViewRow extraHeader2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            extraHeader2.BackColor = Color.LightGreen;
            TableCell cell3 = new TableCell();
            cell3.ColumnSpan = 2;
            extraHeader2.Cells.Add(cell3);
            TableCell cell4 = new TableCell();
            cell4.Text = "A";
            extraHeader2.Cells.Add(cell4);
            TableCell cell5 = new TableCell();
            cell5.Text = "B";
            extraHeader2.Cells.Add(cell5);
            TableCell cell6 = new TableCell();
            cell6.Text = "C";
            extraHeader2.Cells.Add(cell6);
            //create the third row
            GridViewRow extraHeader3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            extraHeader3.BackColor = Color.LightBlue;
            //loop all the columns and create a new cell for each
            for (int i = 0; i < gv.Columns.Count; i++)
            {
                TableCell cell = new TableCell();
                if (i == 0)
                    cell.Text = "Foo";
                else if (i == 1)
                    cell.Text = "Bar";
                else
                    cell.Text = (i - 1).ToString();
                extraHeader3.Cells.Add(cell);
            }
            //add the new rows to the gridview
            gv.Controls[0].Controls.AddAt(0, extraHeader3);
            gv.Controls[0].Controls.AddAt(0, extraHeader2);
            gv.Controls[0].Controls.AddAt(0, extraHeader1);
        }
    }

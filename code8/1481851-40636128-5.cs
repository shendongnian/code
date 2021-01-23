    protected void pagerViewAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //check if the row is the pager row
        if (e.Row.RowType == DataControlRowType.Pager)
        {
            //cast the sender back to a gridview
            GridView gridView = sender as GridView;
    
            //get the id of the gridview as a string
            string senderID = gridView.ID;
    
            //create a new linkbutton
            LinkButton linkButton = new LinkButton();
            linkButton.ID = senderID + "_ShowAll";
            linkButton.Text = "Show All";
            linkButton.CommandName = senderID;
    
            //add the viewAll_Command to the linkbutton
            linkButton.Command += new CommandEventHandler(viewAll_Command);
    
            //get the first table cell from the pager row (there is only one, spanned across all colums)
            TableCell pagerCell = e.Row.Cells[0];
    
            //cast the first control found in the pager cell as a table
            Table table = pagerCell.Controls[0] as Table;
    
            //then the first row of the table containing the pager buttons
            TableRow row = table.Rows[0];
    
            //add an empty cell for spacing
            TableCell tableCellSpacer = new TableCell();
            tableCellSpacer.Text = "&nbsp;-&nbsp;";
            row.Cells.Add(tableCellSpacer);
    
            //then add the cell containing the view all button
            TableCell tableCell = new TableCell();
            tableCell.Controls.Add(linkButton);
            row.Cells.Add(tableCell);
        }
    }
    

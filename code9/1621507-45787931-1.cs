       protected void gvApsimFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Don't interfere with other commands.
            // We may not have any now, but this is another safe-code strategy.
            if (e.CommandName == "CellSelect")
            {
                // Unpack the arguments.
                String[] arguments = ((String)e.CommandArgument).Split(new char[] { ',' });
                // More safe coding: Don't assume there are at least 2 arguments.
                // (And ignore when there are more.)
                if (arguments.Length >= 2)
                {
                    // And even more safe coding: Don't assume the arguments are proper int values.
                    int rowIndex = -1, cellIndex = -1;
                    bool canUpdate = false;
                    int.TryParse(arguments[0], out rowIndex);
                    int.TryParse(arguments[1], out cellIndex);
                    bool.TryParse(arguments[2], out canUpdate);
                    // Use the rowIndex to select the Row, like Select would do.
                    if (rowIndex > -1 && rowIndex < gvApsimFiles.Rows.Count)
                    {
                        gvApsimFiles.SelectedIndex = rowIndex;
                    }
                    //here we either update the Update Panel (if the user clicks only anything OTHER THAN our'Button'
                    //or we process the UpdatePullRequest as Merged
                    if (cellIndex == 5 && canUpdate == true)
                    {
                        int pullRequestId = int.Parse(gvApsimFiles.Rows[rowIndex].Cells[0].Text);
                        UpdatePullRequestMergeStatus(pullRequestId, true);
                    }
                    else
                    {
                        int pullRequestId = int.Parse(gvApsimFiles.Rows[rowIndex].Cells[0].Text);
                        BindSimFilesGrid(pullRequestId);
                    }
                }
            }
        }
        protected void gvApsimFiles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Show as green if 100% 
                if (e.Row.Cells[3].Text.Equals("100"))
                {
                    e.Row.ForeColor = Color.Green;
                }
                e.Row.Attributes["style"] = "cursor:pointer";
                //Active cell click events on individual cells, instead of the row
                foreach (TableCell cell in e.Row.Cells)
                {
                    // Although we already know this should be the case, make safe code. Makes copying for reuse a lot easier.
                    if (cell is DataControlFieldCell)
                    {
                        int cellIndex = e.Row.Cells.GetCellIndex(cell);
                        bool canUpdate = false;
                        // if we are binding the 'Button' column, and the "IsMerged' is false, then whe can Update the Merge Status.
                        if (cellIndex == 5 && e.Row.Cells[2].Text.ToLower().Equals("false"))
                        {
                            canUpdate = true;
                        }
                        // Put the link on the cell.
                        cell.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvApsimFiles, String.Format("CellSelect${0},{1},{2}", e.Row.RowIndex, cellIndex, canUpdate));
                        // Register for event validation: This will keep ASP from giving nasty errors from getting events from controls that shouldn't be sending any.
                        Page.ClientScript.RegisterForEventValidation(gvApsimFiles.UniqueID, String.Format("CellSelect${0},{1},{2}", e.Row.RowIndex, cellIndex, canUpdate));
                    }
                }
            }
        }

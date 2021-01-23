    protected void ShowPolicy_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == ("Proceed"))
                {
                    GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
                    txtBoxId.Text = Convert.ToString(ShowPolicy.DataKeys[currentRowIndex].Value);
                    txtAnotherBox.Text =  Convert.ToString(row.Cells[1].Text)
                    //Similarly you can do for other cells.
                    
                }
            }

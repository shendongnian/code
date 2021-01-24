            protected void GridViewResults_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "hotelId")
                {
                    int rowindex = Convert.ToInt32(e.CommandArgument);
                    int hotelId = Convert.ToInt32(GridViewResults.DataKeys[rowindex].Value);
                }
            }

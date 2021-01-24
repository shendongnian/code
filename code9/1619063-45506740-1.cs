    public void RefreshPages()
            {
                if (Session["SelectedMovies"] != null)
                {
                    DataTable MovieTable = (DataTable)Session["SelectedMovies"];
                    gvCart.DataSource = MovieTable;
                    gvCart.DataBind();
                }
            }
        protected void RemCart(object sender, EventArgs e)
        {
            // Check session exists 
            if (Session["selectedMovies"] != null)
            {
                // Opening / Retreiving DataTable.
                DataTable MovieTable = (DataTable)Session["SelectedMovies"];
                foreach (GridViewRow row in gvCart.Rows)
                {
                    CheckBox chkRemCart = row.Cells[0].FindControl("chkRemCart") as CheckBox;
                    if (chkRemCart != null && chkRemCart.Checked)
                    {
                        //  Error appearing on line below.  Scroll right to read.
                        int MovieId = Convert.ToInt32(gvCart.DataKeys[row.RowIndex].Value); // Error here. //Additional information: Index was out of range. Must be non - negative and less than the size of the collection. 
                        DataRow[] drs = dt.Select("MovieId = '" + MovieId + "'"); // replace with your criteria as appropriate
                        if (drs.Length > 0)
                        {
                            MovieTable.Rows.Remove(drs[0]);
                        }
                    }
                }
                //Saving session
                Session["selectedMovies"] = MovieTable;
                // Updating gvCart
                gvCart.DataSource = MovieTable;
                gvCart.DataBind();
            }
        }

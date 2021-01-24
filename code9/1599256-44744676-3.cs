    public void grid_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // If multiple ButtonField column fields are used, use the
            // CommandName property to determine which button was clicked.
            if (e.CommandName == "Select")
            {
                // get text from LinkButton e.g. URL as in question
                string link = ((LinkButton)selectedRow.FindControl("lbFile")).Text;
                // Redirect to the URL link
                Response.Redirect(link);
            }
        }

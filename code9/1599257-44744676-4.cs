    public void Rssfeed_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // get text from LinkButton e.g. URL as in question
                string link = ((LinkButton)selectedRow.FindControl("lbFile")).Text;
                // Redirect to the URL link
                Response.Redirect(link);
            }
        }

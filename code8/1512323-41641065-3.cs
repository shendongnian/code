    protected void gvPayees_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Sign")
        {
            GridViewRow gvr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
    
            int RowIndex = gvr.RowIndex;
            gvPayees.SelectedIndex = RowIndex;    
        }
    }

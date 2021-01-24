    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            // get row where clicked
            GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            
            Label txt = row.FindControl("Label1") as Label;
            string name = txt.Text;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
           if (e.CommandName == "Select")
            {
                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                int index = row.RowIndex;
 
                string url = (GridView1.Rows[index].FindControl("URL") as Control).Text;
                Response.Redirect(url); // url can be from your sql table
            }    
    }

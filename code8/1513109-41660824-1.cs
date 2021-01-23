    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //getting rowindex which we have selected by using CommandArgument
            int rowindex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "FindName")
            {
               Label5.Text= GridView1.Rows[rowindex].Cells[1].FindControl("eForNames");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    } 

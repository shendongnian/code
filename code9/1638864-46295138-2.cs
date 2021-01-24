    protected void my_testgrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            string arg = e.CommandArgument.ToString();
        }
    }

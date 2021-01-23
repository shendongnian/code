    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SignOut")
        {
            string sn = e.CommandArgument.ToString();
            if (sn == "1")
            {
                /*DO STUFF....*/
            }
        }
    }

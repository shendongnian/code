    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "Reserve")
        {
            string columnValue = e.CommandArgument.ToString();
        }
    }

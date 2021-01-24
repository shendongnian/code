    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "myCommand")
        {
            Label1.Text = e.CommandArgument.ToString();
        }
    }

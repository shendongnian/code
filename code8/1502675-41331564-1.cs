    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string commandArgument = e.CommandArgument.ToString();
    
        if (e.CommandName == "img")
        {
            Response.Write("event is fired: " + commandArgument);
        }
        else if (e.CommandName == "btn1")
        {
            Session["id"] = commandArgument;
        }
    }

    lb.Command += new CommandEventHandler(test_Click);
    protected void test_Click(object sender, CommandEventArgs e)
    {
        Response.Write(e.CommandArgument + "<br>" + e.CommandName);
    }

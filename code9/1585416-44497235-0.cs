    protected void dlReplies_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //check for the correct commandname
        if (e.CommandName == "Add")
        {
            //use findcontrol to find the textbox and cast it back to one
            TextBox tb = e.Item.FindControl("txtReply") as TextBox;
            Label1.Text = tb.Text;
        }
    }

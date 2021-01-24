    protected void GrdArticles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //int index = Convert.ToInt32(e.CommandArgument); //wrong. CommandArgument is not set and is empty by default
        GridViewRow selectedRow = ((Control)e.CommandSource /*that is Button*/).NamingContainer;
           //row is found
        //There are three buttons in each row which should be processed differently
        if(e.CommandName == "rank"){
            //do something
        }
        else if(e.CommandName == "addComment"){
            //addComment
            TextBox txt = (TextBox)selectedRow.FindControl("txtComments");//correct
            DropDownList drp = (DropDownList)selectedRow.FindControl("drpRank");//correct
        }
        .
        .
        .
    }

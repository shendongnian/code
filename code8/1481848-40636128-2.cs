    //find the datapager inside the listview
    DataPager dataPager = ListView1.FindControl("DataPager1") as DataPager;
    
    //add some spacing
    Literal literal = new Literal();
    literal.Text = "&nbsp;-&nbsp;";
    
    //add the literal to the datapager
    dataPager.Controls.Add(literal);
    
    //create a new linkbutton
    LinkButton linkButton = new LinkButton();
    linkButton.ID = senderID + "_ShowAll";
    linkButton.Text = "Show All";
    linkButton.CommandName = senderID;
    
    //add the viewAll_Command to the linkbutton
    linkButton.Command += new CommandEventHandler(viewAll_Command);
    
    //add the linkbutton to the datapager
    dataPager.Controls.Add(linkButton);

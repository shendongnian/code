     protected void GridExample_RowCommand(object sender,GridViewCommandEventArgs e)
     {
        if (e.CommandName == "lbtnStackExample")
       {
        LinkButton lnkbtn = (LinkButton)e.CommandSource;
        string Id= lnkbtn.CommandArgument;
      // write link button click event code here
       }
     }

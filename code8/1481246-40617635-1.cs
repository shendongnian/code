    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      switch(e.CommandName)
      {
        case "Accept":
          var email = e.CommandArgument.ToString();
          Accept(email); // write this function
          break;
      }
    }

    List<Item> myCollection = ...; // get list of items
    myRepeater.DataSource = myCollection;
    myRepeater.DataBind();
...
    protected void myRepeater_ItemCommand(Object sender, RepeaterCommandEventArgs e) 
    {
          if(e.CommandName == "Click")
          {
              int idRecord = Convert.ToInt32(e.CommandArgument);
              // do something using idRecord or
              // get sender properties: ((Button)e.CommandSource).Text
          }
    }  

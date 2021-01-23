    protected void Page_Init(object sender, EventArgs e)
    {
       int i = 0;
       foreach(var foo in bar){
          Button b = new Button();
          b.ID = "button" + i.ToString();
          b.CommandName = "var_value";
          .CommandArgument = foo;
          b.Command += Execute_Command;
    
          //add to panel p
          p.Controls.Add(b);
    
          i++;
       }
    }

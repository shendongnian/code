    Dictionary<string, PictureBox> buttonList = new Dictionary<string,PictureBox>();
    string buttonName = "button_file";
    buttonList[buttonName].Command += buttonList_Command;
    buttonList[buttonName].CommandName = buttonName;
    protected void buttonList_Command(object sender, CommandEventArgs e)
    {
         switch (e.CommandName)
         {
              case buttonName:
                  //Do stuff for button_file
                  break;
              case "Foo":
                  //Do stuff for some other button named foo
                  break;
              default:
                  throw new InvalidOperationException();
         }
     }

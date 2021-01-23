    Textbox myTxtbx = new Textbox();
    myTxtbx.Text = "Enter text here...";
    
    myTxtbx.GotFocus += GotFocus.EventHandle(RemoveText);
    myTxtbx.LostFocus += LostFocus.EventHandle(AddText);
    
    public void RemoveText(object sender, EventArgs e)
    {
         if (myTxtbx.Text == "Enter text here...") {
            myTxtbx.Text = "";
         }
    }
    
    public void AddText(object sender, EventArgs e)
    {
         if(String.IsNullOrWhiteSpace(myTxtbx.Text))
            myTxtbx.Text = "Enter text here...";
    }

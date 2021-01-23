    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        string ControlName = ((YourUserControl)sender).Name;
    
        if(ControlName == "FirstUserControl")
            Response.Write ("You are working on FirstUserControl")
    
        if(ControlName == "LastUserControl")
            Response.Write ("You are working on LastUserControl")
    }

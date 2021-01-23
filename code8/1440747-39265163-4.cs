    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        Control control = (TextBox)sender;
		while (control as YourUserControl == null)
		{
			control = control.Parent;
		}
		
        string ControlName = ((YourUserControl)control).Name;
    
        if(ControlName == "FirstUserControl")
            Response.Write ("You are working on FirstUserControl")
    
        if(ControlName == "LastUserControl")
            Response.Write ("You are working on LastUserControl")
    }

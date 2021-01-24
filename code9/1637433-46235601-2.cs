    foreach(var page in tabControl1.TabPages){
    	var server = ProcessControls(page.Controls, "txtServer");
    	//... continue with the others
    }
    
    private TextBox ProcessControls(Control ctrlContainer, string name) 
    { 
        foreach (Control ctrl in ctrlContainer.Controls) 
        { 
            if (ctrl.GetType() == typeof(TextBox)) 
            { 
                if(ctrl.Name.StartsWith(name))
    				return (TextBox)ctrl;
            }
        } 
    }

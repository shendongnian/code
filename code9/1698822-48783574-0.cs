    string valueFormat3 = string.Empty;
    string finalString3 = string.Empty;
    
    //Get values of checklist items
    foreach (System.Web.UI.WebControls.ListItem checkItem in tSChoices.Items)
    {
    	if (checkItem.Selected)
    	{ //build string
    		valueFormat3 = string.Concat("#", checkItem.Value, ";");
    		finalString3 += valueFormat3;
    	}
    }          
    if (!string.IsNullOrEmpty(finalString3))
    {
    	//trim final string of leading and ending characters
    	finalString3 = finalString3.Substring(1, finalString3.Length - 2);
    }

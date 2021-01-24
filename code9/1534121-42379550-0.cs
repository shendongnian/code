    double weekhours;
    if (!double.TryParse(txtWeekHours.Text, out weekhours)) 
    {
    	//tell user he didn't enter valid number...
    }
    else
    {
    	// do something with weekhours variable which now holds double(decimal) value
    }
    
    double weekendhours;
    if (!double.TryParse(txtWeekendHours.Text, out weekendhours)) 
    {
    	//tell user he didn't enter valid number for weekendhours...
    }
    else
    {
    	// do something with weekendhours variable which now holds double(decimal) value
    }
    
    //etc...

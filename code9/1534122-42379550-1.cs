    double weekhours;
    if (double.TryParse(txtWeekHours.Text, out weekhours)) 
    {
    	// do something with weekhours variable which now holds double(decimal) value
    }
    else
    {
        //tell user he didn't enter valid number...
    	// do something with weekhours variable which now holds double(decimal) value
    }
    
    double weekendhours;
    if (double.TryParse(txtWeekendHours.Text, out weekendhours)) 
    {
    	// do something with weekendhours variable which now holds double(decimal) value
    }
    else
    {
    	//tell user he didn't enter valid number for weekendhours...
    }
    
    //etc...

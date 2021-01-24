    var UKCulture = new CultureInfo("en-GB");
    var USCulture = new CultureInfo("en-US");
    DateTime dt;
    string cellvalue; 
    
    string oData = "13/2/2016"; 
    
    // First try parsing to UK format
    if (!DateTime.TryParse(oData, UKCulture, DateTimeStyles.None, out dt)) 
    { 
        // If fails, then try US format
    	DateTime.TryParse(oData, USCulture, DateTimeStyles.None, out dt);
    }
    
    // Once you have DateTime instance, you can do anything. Parsing is over.
    cellvalue = dt.ToString("dd/MM/yyyy"); 
    Console.Write(cellvalue);

    // In the main method get your edmx/designer 
    //EDMX File location
    string pathFile = @"c:\Path\To\DbModel.edmx";
    //Designer location for EF 5.0
    string designFile = @"c:\Path\To\DbModel.edmx.diagram";
    // ...
    // replace the PascalCase method with this
    public static string PascalCase(string name, bool sanitizeName = true, bool pluralize = false)
    {
    
    	// if pascal case exists
    	// exit function
    
    	Regex rgx = new Regex(@"^[A-Z][a-z]+(?:[A-Z][a-z]+)*$");
    
    	string pascalTest = name;
    
    	if (name.Contains("."))
    	{
    		string[] test = new string[] { };
    		test = name.Split('.');
    
    		if (rgx.IsMatch(test[1].ToString()))
    		{
    			return name;
    		}
    
    	}
    	else
    	{
    
    		if (rgx.IsMatch(name))
    		{
    			return name;
    		}
    
    	}
    
    	//Check for dot notations in namespace
    	string result;
    	bool contains = false;
    	string[] temp = new string[] { };
    	var namespc = string.Empty;
    
    	if (name.Contains("."))
    	{
    		contains = true;
    		temp = name.Split('.');
    		namespc = temp[0];
    
    	}
    
    	if (contains)
    	{
    		name = temp[1];
    	}
    
    	name = name.ToLowerInvariant(); // this may or may not be required
        // Here's the simplified snake to pascal case
    	result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name).Replace("_", "");
    
    	if (contains)
    	{
    		result = namespc.ToString() + "." + result;
    	}
    
    	if (pluralize)
    	{
    		result = Pluralize(result);
    	}
    	return result;
    }

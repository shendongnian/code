    public static string MoneyToDatabase(string value, int decimal_places)
    {
    	if(string.IsNullOrEmpty(value) == true)
    		return "0.00";
    
    	value = value.Replace(",", ".");
    
    	string format = "F" + decimal_places;
    
    	double valueAsDouble;
    	double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out valueAsDouble);
        
        // It sets again a comma in the string and must be replaced
    	return valueAsDouble.ToString(format).Replace(",", ".");
    }

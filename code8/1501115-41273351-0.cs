    public double CurrencyToDouble(string input)
    {
        // Will hold the result
	    double result = 0;
	
        // Try current system culture
        if(double.TryParse(input, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out result)) { return result; }
        // Try invariant culture
	    if(double.TryParse(input, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.InvariantCulture, out result)) { return result; }
	
        // Try DE culture
	    if (double.TryParse(input, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.GetCultureInfo("de-DE"), out result)) { return result; }
	
        // Try more common cultures...
        // Unsuccessful, throw some kind of error
	    throw new FormatException("Could not convert!");
    }

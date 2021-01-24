    private bool IsValidDate(string day, string month, string year)
    {
    	int i;
    	//check if all those values for date/month/year can be converted to number
    	if (!int.TryParse(day, out i) || !int.TryParse(day, out i) || !int.TryParse(day, out i))
    		return false;
    
		//now check if date, written in format dd.MM.yyyy can be converted to DateTime.
		DateTime dt;
		string stringDate = day.PadLeft(2, '0') + "." + month.PadLeft(2, '0') + "." + year;
		return DateTime.TryParseExact(stringDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
    
    }

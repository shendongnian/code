    private bool IsValidDate(string day, string month, string year)
    {
    	int i;
    	//check if all those values for date/month/year can be converted to number
    	if (!int.TryParse(day, out i) || !int.TryParse(day, out i) || !int.TryParse(day, out i))
    		return false;
    
    	DateTime dt;
    	string stringDate = day + "." + month + "." + year;
    	return DateTime.TryParse(stringDate, out dt);
    
    }

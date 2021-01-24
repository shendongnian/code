    private DateTime ParseDateTimeField(string date)
	{
        //If our string is not null
		if (!string.IsNullOrWhiteSpace(date))
			return DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
		else
            //Do something like return a specific date or maybe today.
			//return DateTime.Today;
	}

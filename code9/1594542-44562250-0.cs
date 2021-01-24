	if (record.PriceModified.Date != DateTime.Now.Date)
	{
		// First edit for today. 
		if (PriceWithinChangeThreshold(formData.NewPrice, record.CurrentPrice))
		{		
			// Save the old price as the new start price for today
			record.DailyPrice = record.CurrentPrice;
			record.CurrentPrice = formData.NewPrice;
			record.PriceModified = DateTime.Now;
		}
	}
	else
	{
		// This price has already been edited today.
		if (PriceWithinChangeThreshold(formData.NewPrice, record.DailyPrice))
		{
			// But it's within the threshold for today
			record.CurrentPrice = formData.NewPrice;
			record.PriceModified = DateTime.Now;
		}	
	}

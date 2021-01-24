    //Store todays date in a variable so you don't grab it every time 
    //(it changes every "tick" you know)
    var todaysDate = DateTime.Now;
	foreach(var date in sampleDates)
	{
        //Date is out of our 4 "week" range, skip to next loop
		if(date.Date < todaysDate.AddDays(-28).Date || date.Date > todaysDate.Date)
		{
			continue;
		}
			
        //Using simple math we skip a lot of unnecessary code
        //This loop runs 4 times
        //-7 - 0
        //-14 - -7
        //-21 - -14
        //-28 - -21
		for(int i = 0; i < 4; i++)
		{            
			if(DateInRange(date, todaysDate.AddDays((i + 1) * -7), todaysDate.AddDays(-7 * i)))
			{
                //Increment our "week's" counter
				weekCount[i]++;
			}
		}						
	}

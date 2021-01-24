    var dateString = "25/12/2017 4:00 PM";
	DateTime inputDate; 
    if(DateTime.TryParseExact(dateString, "dd/MM/yyyy h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out inputDate))
	{
       var output = inputDate.ToString("MM/dd/yyyy hh:mm tt");
	   Console.WriteLine(output);
	}
	else
	{
		 Console.WriteLine("Conversion failed");
	}

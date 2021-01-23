    Dictionary<DayOfWeek, List<int>> daysCount = new Dictionary<DayOfWeek, List<int>>()
    {
    	{ DayOfWeek.Monday, new List<int>() },
    	{ DayOfWeek.Thursday, new List<int>() },
    	{ DayOfWeek.Wednesday, new List<int>() },
    	{ DayOfWeek.Tuesday, new List<int>() },
    	{ DayOfWeek.Friday, new List<int>() },
    	{ DayOfWeek.Saturday, new List<int>() },
    	{ DayOfWeek.Sunday, new List<int>() },
    };
    
    Console.Write("What is the year? : ");
    var year = Convert.ToInt32(Console.ReadLine());
    Console.Write("What is the name of the month? : ");
    var monthName = Console.ReadLine();
    
    var monthNumber = DateTime.ParseExact(monthName, "MMMM", CultureInfo.CurrentCulture).Month;
    var dayOfMonth = DateTime.DaysInMonth(year, monthNumber);
    
    var date = new DateTime(year, monthNumber, 1);
    
    
    for(int i = 0; i < dayOfMonth; i++, date = date.AddDays(1))
    {
    	
    	if (daysCount[date.DayOfWeek] == null)
    	{
    		daysCount[date.DayOfWeek] = new List<int>();
    	}
    
    	daysCount[date.DayOfWeek].Add(date.Day);
    }
    
    foreach (var day in daysCount)
    {
    	Console.WriteLine(day.Key.ToString());
    	foreach (var dayNumber in day.Value)
    	{
    		Console.Write(string.Format("{0} ", dayNumber));
    	}
    	Console.WriteLine();
    
    }
    
    Console.ReadLine();

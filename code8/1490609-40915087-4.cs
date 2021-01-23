    var days = new List<int>();
    Console.Write("What is the year? : ");
    var year = Convert.ToInt32(Console.ReadLine());
    Console.Write("What is the name of the month? : ");
    var monthName = Console.ReadLine();
    Console.Write("Enter the day you want to see the dates for (Mon = 0, etc): ");
    var promptDay = Convert.ToInt32(Console.ReadLine());
    
    var monthNumber = DateTime.ParseExact(monthName, "MMMM", CultureInfo.CurrentCulture).Month;
    var dayOfMonth = DateTime.DaysInMonth(year, monthNumber);
    
    var date = new DateTime(year, monthNumber, 1);
    
    
    for(int i = 0; i < dayOfMonth; i++, date = date.AddDays(1))
    {
    
    	if ((int)date.DayOfWeek == promptDay)
    		days.Add(date.Day);
    }
    
    foreach (var day in days)
    {
    	Console.Write(string.Format("{0} ", day));
    
    }
    
    Console.ReadLine();

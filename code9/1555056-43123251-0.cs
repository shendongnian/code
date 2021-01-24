    var today = DateTime.Now.Date; // This can be any date.
    Console.WriteLine(today.DayOfWeek);
    var day = (int)today.DayOfWeek; //Number of the day in week. (0 - Sunday, 1 - Monday... and so On)
    Console.WriteLine(day);
    const int totalDaysOfWeek = 7; // Number of days in a week stays constant.
    for (var i = -day; i < -day + totalDaysOfWeek; i++)
    {
         Console.WriteLine(today.AddDays(i).Date);
    }

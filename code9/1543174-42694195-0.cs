    DateTime start = new DateTime(2017, 01, 01);
    DateTime end = new DateTime(2017, 01, 10);
    TimeSpan ts = end - start;
            
    int wrkDays = ts.Days + 1;
    DateTime[] workingDays = new DateTime[wrkDays];
    int i = 0;
    for(DateTime dt = start; dt <= end; dt = dt.AddDays(1))
    {
         workingDays[i] = dt;
         i++;
    }
    int holidays = bankHolidays.Intersect(workingDays).Count();
    int result = wrkDays - holidays;

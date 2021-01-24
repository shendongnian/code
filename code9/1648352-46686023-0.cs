            int doy = DateTime.Now.DayOfYear;// Day of the year
            int yr = DateTime.Now.Year  ;// Two digit year
            string mon = DateTime.Now.Month.ToString("d2"); // Two digit month (zero on left for small numbers)
            string day = DateTime.Now.Day.ToString("d2"); // Two digit day   (zero on left for small numbers)
        Console.WriteLine(doy);
        Console.WriteLine(yr);
        Console.WriteLine(mon);
        Console.WriteLine(day);

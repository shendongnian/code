     using System.Globalization;
     ...
     DateTime userDate;
     // Gathering UserInput (just one simple loop)
     do {
       Console.WriteLine("Please enter the date in the format dd/mm/yyyy");
     } 
     while (!DateTime.TryParseExact(Console.ReadLine(), 
       "d/m/yyyy", // be nice, let 21.5.2017 be valid; please, do not inist on 21.05.2017 
        CultureInfo.InvariantCulture, 
        DateTimeStyles.AssumeLocal, 
        out userDate));
     // If you insist on these local variables
     int day = userDate.Day;
     int month = userDate.Month;
     int year = userDate.Year;

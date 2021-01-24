    string inputDateStr = "02/01/2017 10:00";
    DateTime inputDate;
    if (DateTime.TryParseExact(inputDateStr, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out inputDate))
    {
        Console.WriteLine("Date time Now  : {0} ", inputDate);
        Console.WriteLine("Date time UTC  : {0} ", inputDate.ToUniversalTime());                
    }

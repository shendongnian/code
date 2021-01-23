    string inputString = "2016-08-31T18:30:00.000Z";
         
    DateTime dDate;
    
    if (DateTime.TryParse(inputString, out dDate))
    {
        DateTime correctedDateTime = TimeZoneInfo.ConvertTime(dDate, TimeZoneInfo.Local);
        // write this here back into the array using your format
        Console.WriteLine(correctedDateTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
    }
    else
    {
        Console.WriteLine("Invalid"); // <-- Control flow goes here
    }

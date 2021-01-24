    string dateString = "03/01/2009 10:00 AM";
    DateTime dateTime;
    if (DateTime.TryParse(dateString , out dateTime))
    {
        Console.WriteLine(dateTime);
    }

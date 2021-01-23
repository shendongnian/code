    // Static property to get the current time, in UTC.
    DateTimeOffset now = DateTimeOffset.UtcNow;
    string dateString = "09/09/1990";
    DateTimeOffset date;
    // Use TryParse to defensively parse the date.
    if (DateTimeOffset.TryParse(dateString, out date))
    {
        // The date is valid; we can use a standard operator to compare it.
        if (date < now)
        {
            Console.WriteLine("The parsed date is in the past.");
        }
        else
        {
            Console.WriteLine("The parsed date is in the future.");
        }
    }

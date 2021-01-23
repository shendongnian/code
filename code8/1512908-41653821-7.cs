    foreach (var item in baseservices)
    {
        foreach (var date in item.Dates)
        {
            Console.WriteLine(item.Price + " " + date.PeriodStart + " " + date.PeriodEnd);
        }
    }

    var xmlDate = "03/20/17";
    DateTime orderDate;
    // The first 'TryParse...' that succeeds will store the parsed date in 'orderDate'
    if (!DateTime.TryParseExact(xmlDate, "M/d/yyyy", new CultureInfo("en-US"),
        DateTimeStyles.None, out orderDate))
    {
        if (!DateTime.TryParseExact(xmlDate, "M/d/yy", new CultureInfo("en-US"),
            DateTimeStyles.None, out orderDate))
        {
            if (!DateTime.TryParse(xmlDate, out orderDate))
            {
                // Couldn't parse, so use a default date, or log an error..?
                orderDate = DateTime.Today;
                Console.WriteLine($"Error: Unable to convert to date: {xmlDate}");
            }
        }
    }
    Console.WriteLine($"Order date: {orderDate.ToString("MM/dd/yyy")}");

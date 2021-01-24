    var dates = new[] { "12.12.2017", "12.02.2017", "12.2.2017", "02.12.2017", "2.12.2017", "02.02.2017", "2.2.2017" };      
    foreach (var dateStr in dates)
    {
        DateTime dt;
        if (!DateTime.TryParse(dateStr, CultureInfo.CurrentUICulture, DateTimeStyles.None, out dt))
        {
            Console.WriteLine("not valid: " + dateStr);
        }
    }  

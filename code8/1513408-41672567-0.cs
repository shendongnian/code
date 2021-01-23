    List<string> dateTimes = new List<string>();
    dateTimes.Add("10/31/2015 12:00:00 AM");
    var selectValue = dateTimes.Select(d => d)
           .AsEnumerable()
           .Select(d => DateTime.ParseExact(d, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture).Date).ToList();
    var r = DateTime.ParseExact("10/31/2015 12:00:00 AM", "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

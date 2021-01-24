    var n = 137;
    var begin = DateTime.Today;
    var end = begin.AddDays(n);
    var holidays = GenerateHolidays(begin, end); // or use your own IEnumerable<DateTime> here
    var dates = Enumerable
        .Range(0, (end - begin).Days)
        .Select(a => begin.AddDays(a))
        .Except(holidays);

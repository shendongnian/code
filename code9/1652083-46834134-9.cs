    var n = 137;
    var begin = DateTime.Today;
    var end = begin.AddDays(n);
    var dates = Enumerable
        .Range(0, (end - begin).Days)
        .Select(a => begin.AddDays(a))
        .Except(GenerateHolidays(begin, end)); // or use your own IEnumerable<DateTime> of holidays here

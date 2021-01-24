    // get array with dates
    var arrayWithDates = array.Select(el => 
        new
        {
            Date = DateTime.ParseExact(el.DateString, "yyyy-M-d", CultureInfo.InvariantCulture),
            SomeInt = el.SomeInt
        });
    // get minimum date
    DateTime minDate = arrayWithDates.Min(el => el.Date);
    // get maximum date
    DateTime maxDate = arrayWithDates.Max(el => el.Date);
    int days = (maxDate - minDate).Days;
    // getting all dates from minDate to maxDate
    IEnumerable<DateTime> dateRange = Enumerable.Range(0, days + 1)
        .Select(el => minDate.AddDays(el));
    // split all dates into groups of 5 dates
    IEnumerable<DateTime[]> groupedDateRanges = dateRange
        .Select((el, index) => new { el.Date, index })
        .GroupBy(el => el.index / 5)
        .Select(g => g.Select(el => el.Date).ToArray());
    var results = groupedDateRanges
        // getting list of object within each range
        .Select(groupedDateRange => arrayWithDates.Where(el => groupedDateRange.Contains(el.Date)))
        // selecting minimum date of range, maximum date of range and sum by int value
        .Select(item =>
            new
            {
                MinDate = item.Min(el => el.Date),
                MaxDate = item.Max(el => el.Date),
                Sum = item.Sum(el => el.SomeInt)
            });

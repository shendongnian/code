    // Here AddRange would be expected to accept IEnumerable<DateRange>
    dateRange.Ranges.AddRange(new[] {
        new DateRange(LastWeek, "Last Week"),
        new DateRange(LastMonth, "Last 1 Month"),
        new DateRange(Last2Months, "Last 2 Months")
    });

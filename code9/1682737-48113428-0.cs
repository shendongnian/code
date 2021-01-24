    // Names adjusted to follow .NET naming conventions
    public static DateTime FindNearestEndOfMonth(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int daysInMonth = DateTime.DaysInMonth(year, month);
        return date.Day >= daysInMonth / 2
            // End of current month
            ? new DateTime(year, month, daysInMonth)
            // End of previous month
            : new DateTime(year, month, 1).AddDays(-1);
    }

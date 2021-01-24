    public static Period NormalizeIncludingMonths(this Period period, int daysPerMonth)
    {
        period = period.Normalize();
        int extraMonths = days / daysPerMonth;
        int months = period.Months + extraMonths;
        int extraYears = months / 12;
        // Simplest way of changing just a few parts...
        var builder = period.ToBuilder();
        builder.Years += extraYears;
        builder.Months = months % 12;
        builder.Days = days % daysPerMonth;
        return builder.Build();
    }

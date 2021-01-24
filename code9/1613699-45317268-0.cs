    private void btndatetime_Click(object sender, RoutedEventArgs e)
    {
        DateTime fromOA = FromOAdate(40967.6424503935);
        System.Diagnostics.Debug.WriteLine(fromOA);
        double toOA = ToOAdate(fromOA);
        System.Diagnostics.Debug.WriteLine(toOA);
    }
    public DateTime FromOAdate(double oadate)
    {
        return new DateTime(DoubleDateToTicks(oadate), DateTimeKind.Unspecified);
    } 
    public double ToOAdate(DateTime datetime)
    {
        return TicksToOADate(datetime.Ticks);
    }
    private const long TicksPerMillisecond = 10000;
    private const long TicksPerSecond = TicksPerMillisecond * 1000;
    private const long TicksPerMinute = TicksPerSecond * 60;
    private const long TicksPerHour = TicksPerMinute * 60;
    private const long TicksPerDay = TicksPerHour * 24;
    private const UInt64 TicksMask = 0x3FFFFFFFFFFFFFFF;
    private const long DoubleDateOffset = DaysTo1899 * TicksPerDay;
    // Number of days in a non-leap year
    private const int DaysPerYear = 365;
    // Number of days in 4 years
    private const int DaysPer4Years = DaysPerYear * 4 + 1;       // 1461
    // Number of days in 100 years
    private const int DaysPer100Years = DaysPer4Years * 25 - 1;  // 36524
    // Number of days in 400 years
    private const int DaysPer400Years = DaysPer100Years * 4 + 1; // 146097
    private const int DaysTo1899 = DaysPer400Years * 4 + DaysPer100Years * 3 - 367;
    // Number of milliseconds per time unit
    private const int MillisPerSecond = 1000;
    private const int MillisPerMinute = MillisPerSecond * 60;
    private const int MillisPerHour = MillisPerMinute * 60;
    private const int MillisPerDay = MillisPerHour * 24;
    private static double TicksToOADate(long value)
    {
        if (value == 0)
            return 0.0;  // Returns OleAut's zero'ed date value.
        if (value < TicksPerDay) // This is a fix for VB. They want the default day to be 1/1/0001 rathar then 12/30/1899.
            value += DoubleDateOffset; // We could have moved this fix down but we would like to keep the bounds check.          
        long millis = (value - DoubleDateOffset) / TicksPerMillisecond;
        if (millis < 0)
        {
            long frac = millis % MillisPerDay;
            if (frac != 0) millis -= (MillisPerDay + frac) * 2;
        }
        return (double)millis / MillisPerDay;
    }
    internal static long DoubleDateToTicks(double value)
    {
        // The check done this way will take care of NaN
        //if (!(value < OADateMaxAsDouble) || !(value > OADateMinAsDouble))
        //    throw new ArgumentException(Environment.GetResourceString("Arg_OleAutDateInvalid"));
        // Conversion to long will not cause an overflow here, as at this point the "value" is in between OADateMinAsDouble and OADateMaxAsDouble
        long millis = (long)(value * MillisPerDay + (value >= 0 ? 0.5 : -0.5));
        // The interesting thing here is when you have a value like 12.5 it all positive 12 days and 12 hours from 01/01/1899
        // However if you a value of -12.25 it is minus 12 days but still positive 6 hours, almost as though you meant -11.75 all negative
        // This line below fixes up the millis in the negative case
        if (millis < 0)
        {
            millis -= (millis % MillisPerDay) * 2;
        }
        millis += DoubleDateOffset / TicksPerMillisecond;
        //if (millis < 0 || millis >= MaxMillis) throw new ArgumentException(Environment.GetResourceString("Arg_OleAutDateScale"));
        return millis * TicksPerMillisecond;
    }

     public static TimeSpan? ParseTimeSpan(this string toParse, IFormatProvider formatProvider)
        {
            TimeSpan value;
            if (TimeSpan.TryParse(toParse, formatProvider, out value))
            {
                return value;
            }
            return null;
        }
    [TestMethod()]
    public void ParseTimeSpanTest()
    {
        Assert.AreEqual(ParseTime("5:33"), "5:33".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(ParseTime("9:22"), "9:22".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(ParseTime("8:22"), "8:22".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(ParseTime("7:22:44"), "7:22:44".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(ParseTime("9:22:44"), "9:22:44".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(ParseTime("13:22:14"), "13:22:14".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(ParseTime("23:59:00"), "23:59:00".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(null, "22:59:00 AM".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(null, "23:70:00 PM".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(null, "23:59:75 AM".ParseTimeSpan(CultureInfo.InvariantCulture));
        Assert.AreEqual(null, "five thirty PM".ParseTimeSpan(CultureInfo.InvariantCulture));
        var dt = DateTime.Now;
        Assert.AreEqual(dt.AddHours(1) - dt, "1:00".ParseTimeSpan(CultureInfo.InvariantCulture));
    }
    private static TimeSpan ParseTime(string time)
    {
        return TimeSpan.Parse(time, CultureInfo.InvariantCulture);
    }

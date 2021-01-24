    public DateTime GetQuarterEnd(int month)
    {
        if (month < 1 || month > 12)
            throw new ArgumentException("month is not a valid Month of the year.");
        var mod = month % 3;
        var actual = month / 3 + (mod > 0 ? 1 : 0);
        return new DateTime(DateTime.Now.Year, actual * 3, 15);
    }

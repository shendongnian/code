    public static bool TryParseXsDate(string xsDate, out LocalDate localDate)
    {
        // First try directly, since xsDate's offset is optional.
        var result1 = LocalDatePattern.Iso.Parse(xsDate);
        if (result1.Success)
        {
            localDate = result1.Value;
            return true;
        }
        // Now try with an offset
        var result2 = OffsetDatePattern.Parse(xsDate);
        if (result2.Success)
        {
            localDate = result2.Value.Date;
            return true;
        }
        // Failed parsing
        localDate = default(LocalDate);
        return false;
    }

    private DateTime? TryParseNumberString(string dateText)
    {
        // additional date format options to be accepted
        var extraDateFormats = new[]
        {
            "d.M.",
            "d.M",
            "ddMMyyyy",
            "ddMMyy",
            "ddM"
        };
        foreach (var item in extraDateFormats)
        {
            DateTime test;
            if (DateTime.TryParseExact(dateText, item, null, System.Globalization.DateTimeStyles.AssumeLocal, out test))
            {
                return test;
            }
        }
        return null;
    }

    private static string FormatDate(string sDate)
    {
        // "6/16/1989"
        //mysql format 06-16-1989
        DateTime date;
        if (!DateTime.TryParseExact(sDate, new string[] { "MM/dd/yyyy", "M/dd/yyyy", "MM/d/yyyy" }, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out date))
        {
            return string.Empty;
        }
        return date.ToString("MM-dd-yyyy");
    }

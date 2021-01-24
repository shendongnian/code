    private static string FormatDate(string sDate)
    {
        // "6/16/1989"
        //mysql format 06-16-1989
        var usCultureInfo = System.Globalization.CultureInfo.GetCultureInfo(0x0409);
        DateTime date;
        if (!DateTime.TryParse(sDate, usCultureInfo, System.Globalization.DateTimeStyles.AdjustToUniversal, out date))
        {
            return string.Empty;
        }
        return date.ToString("MM-dd-yyyy");
    }

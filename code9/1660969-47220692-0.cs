    public static bool IsValidDate(string DateStr)
    {
        DateStr = DateStr.Trim();
        DateTime tempDate = new DateTime().Date;
        return DateTime.TryParse(DateStr, new System.Globalization.CultureInfo("de-DE"), System.Globalization.DateTimeStyles.None, out tempDate);
    }

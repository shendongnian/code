    public static string ConvertDateCreated(string dateCreated)
    {
        System.Globalization.CultureInfo provider = 
             System.Globalization.CultureInfo.InvariantCulture;
        return DateTime.ParseExact(dateCreated, "M/dd/yyyy hh:mm:ss tt", provider)
                 .ToString("yyyyMMdd");
    }

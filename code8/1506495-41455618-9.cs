    public static string GetDateTime(string value)
    {
        DateTime date;
        string dateString = ""; // Empty by default
    
        // If full date is given, this will succeed
        if (DateTime.TryParse(value, out date))
        {
            dateString = date.ToShortDateString();
        }
        // If only year is given then this will succeed
        else if (DateTime.TryParseExact(value,
                "yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
        {
            dateString = date.ToShortDateString();
        }
    
        return dateString;
    }

    public static LocalTime ParseTimeString(string timeString)
    {
        var pattern = LocalTimePattern.CreateWithInvariantCulture("h:mm tt");
        return pattern.Parse(timeString).Value;
    }

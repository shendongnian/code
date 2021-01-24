    if(DateTime.TryParseExact($"{a_item.EventDate} {a_item.EventTime}", "MMMM d, yyyy h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out eventDateTime))
    {
        // eventDateTime now holds correct datetime, assuming the data transfered was correct. 
    }
    else
    {
        // Failed to parse string as datetime.
    }

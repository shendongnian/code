    // your input string
    string green = "2017-01-10T13:19:00-07:00";
    // parse to a DateTimeOffset
    DateTimeOffset dto = DateTimeOffset.Parse(green);
    // find the time zone that you are interested in
    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    // convert the DateTimeOffset to the time zone
    DateTimeOffset eastern = TimeZoneInfo.ConvertTime(dto, tzi);
    // If you need it, you can get just the DateTime portion.  (Its .Kind will be Unspecified)
    DateTime dtEastern = eastern.DateTime;

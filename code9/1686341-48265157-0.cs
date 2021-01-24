    //set variables
    var centralTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time");
    var ISODateStyle = System.Globalization.DateTimeStyles.RoundtripKind;
    //parse date
    var date = DateTime.Parse(inputDate, null, ISODateStyle);
    // change time zone
    var newDate = TimeZoneInfo.ConvertTime(date, centralTimeZone);

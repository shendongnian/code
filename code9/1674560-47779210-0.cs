    string PurchaseDate = "2017-12-12T14:29:26Z";
    DateTime dt = DateTime.ParseExact(PurchaseDate, "yyyy-MM-ddTHH:mm:ssK",
                                   CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("...you'll need to decide...");
    DateTime clientDateTime = TimeZoneInfo.ConvertTimeFromUtc(dt, tz);

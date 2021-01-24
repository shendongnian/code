    var culture = (CultureInfo) CultureInfo.InvariantCulture.Clone();
    var field = typeof(DateTimeFormatInfo).GetField("generalLongTimePattern",
                                               BindingFlags.NonPublic | BindingFlags.Instance);
    if (field != null)
    {
        // we found the internal field, set it
        field.SetValue(culture.DateTimeFormat, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFFK");
    }
    else
    {
        // fallback to setting the separate date and time patterns
        culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
        culture.DateTimeFormat.LongTimePattern = "HH:mm:ss.FFFFFFFK";
    }
    CultureInfo.CurrentCulture = culture;
    Console.WriteLine(DateTime.UtcNow);  // "2017-11-07T00:53:36.6922843Z"

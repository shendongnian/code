    string fromDate = "2016/10/20/12:13:14";
    DateTime fromDaten = DateTime.MinValue;
    bool fromParsed = DateTime.TryParseExact(fromDate, "yyyy/MM/dd/HH:mm:ss", 
        new System.Globalization.CultureInfo("en-US"), 
        System.Globalization.DateTimeStyles.None, out fromDaten);
    // you may check fromParsed and handle invalid date/time 

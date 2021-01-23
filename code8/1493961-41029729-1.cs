    DateTime dt;
    bool parsed = DateTime.TryParseExact("119.08", 
        "yyyy-dd-MM hh:mm tt", 
        System.Globalization.CultureInfo.InvariantCulture, 
        System.Globalization.DateTimeStyles.None, 
        out dt ); 

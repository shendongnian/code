    // takes an object, returns a DateTime or null in case of failure
    DateTime FormatDateTime(object ObjInstallDate)
    {
        DateTime dtm;
        if (!DateTime.TryParseExact(
            (string) ObjInstallDate, // notice that we don't hassle with the input here, 
                                     // only cast to a string
                                     // we simply rely on the parser of DateTimer.TryParseExact
            "yyyyMMddhhmmss.ffffff-000",  // this matches the format
                                          // if the -000 represents a timezone
                                          // you can use z00 or zz0 
                                          // don't use zzz as that expects -0:00
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None, 
            out dtm)) 
        {
            // an invalid date was supplied, maybe throw, at least log
            Console.WriteLine("{0} is not valid", ObjInstallDate);
        }
        // we either return here null or a valid date
        return dtm; // !! No ToString() here
    }

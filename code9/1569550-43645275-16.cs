   
    // These are just plain unspecified DateTimes
    DateTime dtOneAm = new DateTime(2017, 03, 12, 01, 00, 00);
    DateTime dtFourAm = new DateTime(2017, 03, 12, 04, 00, 00);
    // The difference is not going to do anything other than 4-1=3
    TimeSpan difference1 = dtFourAm - dtOneAm;
    // ... but we have a time zone to consider!
    TimeZoneInfo eastern = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    
    // Use that time zone to get DateTimeOffset values.
    // The GetUtcOffset method has what we need.
    DateTimeOffset dtoOneAmEastern = new DateTimeOffset(dtOneAm, eastern.GetUtcOffset(dtOneAm));
    DateTimeOffset dtoFourAmEastern = new DateTimeOffset(dtFourAm, eastern.GetUtcOffset(dtFourAm));
    // Subtracting these will take the offset into account!
    // It essentially does this: [4-(-4)]-[1-(-5)] = 8-6 = 2
    TimeSpan difference2 = dtoFourAmEastern - dtoOneAmEastern;
    
    // Let's see the results
    Console.WriteLine("dtOneAm: {0:o} (Kind: {1})", dtOneAm, dtOneAm.Kind);
    Console.WriteLine("dtFourAm: {0:o} (Kind: {1})", dtFourAm, dtOneAm.Kind);
    Console.WriteLine("difference1: {0}", difference1);
    
    Console.WriteLine("dtoOneAmEastern: {0:o})", dtoOneAmEastern);
    Console.WriteLine("dtoFourAmEastern: {0:o})", dtoFourAmEastern);
    Console.WriteLine("difference2: {0}", difference2);

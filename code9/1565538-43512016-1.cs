      string source = Console.ReadLine();
      DateTime date;
    
      // DateTime.TryParseExact supports many formats; that's why "12:34AM" will be accepted
      // DateTimeStyles.AllowWhiteSpaces let us be nice and allow, say "11 : 34 : 47 PM"
      if (DateTime.TryParseExact(
            source, 
            new string[] {"h:m:stt" , "h:mtt", "htt", "H:m:s", "H:m", "H"}, 
            CultureInfo.InvariantCulture, // or CultureInfo.CurrentCulture
            DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces, 
            out date)) 
        Console.WriteLine(date.ToString("HH:mm:ss"));
      else
        Console.WriteLine($"Sorry, {source} is not a valid date");

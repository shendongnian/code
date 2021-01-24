    var date = "2017-01-02";
    
    var formats = new Dictionary<string,int>();
    
    // go over all cultures
    foreach(var ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
    {
      // each culture has a DateTimeFormatInfo that holds date and time patterns
      foreach(var p in typeof(DateTimeFormatInfo).GetProperties().Where(prop => prop.Name.EndsWith("Pattern")))
      { 
        // get a pattern
        var fmt = (string) p.GetValue(ci.DateTimeFormat,null);
        try
        {
          // try to parse the date
          DateTime.ParseExact(date,fmt , ci);
          // add the format
          if (formats.Keys.Contains(fmt))
          {
             formats[fmt]++; // how often this was a valid date
          }
          else
          {
             formats.Add(fmt, 1); // first time we found it
          }
        }
        catch
        {
         // no date in this culture for this format, ignore
        }
       
      }
    }
    
    // output the formats that were parsed as a date
    foreach(var kv in formats)
    {
       // Dump is a linqPad extension, use Console.WriteLine if that bothers you
       kv.Value.Dump(kv.Key);
    }

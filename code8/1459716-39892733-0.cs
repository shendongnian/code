      string source = "10 Mar 16";
      ...
      // Put all allowed formats here 
      string[] formats = new string[] {
        "d MMMM yyyy",
        "d MMM yyyy",
        "d MMM yy"
      };
      if (DateTime.TryParseExact(source, 
                                 formats, 
                                 CultureInfo.InstalledUICulture,
                                 DateTimeStyles.AssumeLocal, 
                                 out datetime)) {
        // datetime contains valid date and time 
      }
      else {
       // log error: parsing fails
      }
     

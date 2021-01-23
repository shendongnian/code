      private static double InSeconds(string value, params string[] formats) {
        // if no formats provided, use default ones:
        // try these formats in this particular order:
        if ((null == formats) || (formats.Length <= 0))
          formats = new string[] { 
            @"h\:m\:s", 
            @"h\:m", 
            @"m\:s" }
        else
          // In case of unescaped formats like "h:m" (see comments below)
          // we automatically escape them
          for (int i = 0; i < formats.Length; ++i)
            if (formats[i] != null)
              formats[i] = Regex.Replace(formats[i], 
                @"(?<!\\)[^A-Za-z\\]", 
                match => @"\" + match.Value);
        
        TimeSpan result; 
  
        if (TimeSpan.TryParseExact(value, formats, CultureInfo.InvariantCulture, out result))
          return result.TotalSeconds;
        else
          return double.NaN;  
      }
    

      using System.Linq;
      using System.Text.RegularExpressions; 
      ...
      string source = "DISK0123CAR"; 
      // KSID0123RAC 
      string result = Regex.Replace(source, 
        "[^0-9]+",                                        // all except numbers ...
         match => string.Concat(match.Value.Reverse()));  // ... should be reversed

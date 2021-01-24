      using System.Linq;
      ...
      string source = "İntersport";
      // you may want to change 255 to 127 if you want standard ASCII table
      string target = string.Concat(source
        .Select(c => c < 32 || c > 255  
           ? "\\u" + ((int)c).ToString("x4") // special symbol: command one or above Ascii 
           : c.ToString())); // within ascii table [32..255]
      // \u0130ntersport
      Console.Write(target);

        class Gebruikerklasse {
          ...
          // "A" - Achternaam
          // "G" - Gebruikersnaam
          // "N" - Naam
          // null, empty - default ToString format  
          public string ToString(string format, IFormatProvider formatProvider) {
            if (string.IsNullOrEmpty(format))
              return ToString(); 
            else if ("N".Equals(format, StringComparison.OrdinalIgnoreCase))
              return Naam;
            else if ("A".Equals(format, StringComparison.OrdinalIgnoreCase))
              return Achternaam;
            else if ("G".Equals(format, StringComparison.OrdinalIgnoreCase))
              return Gebruikersnaam;
            else
              throw new FormatException($"Unknown format '{format}'");
          }
          public string ToString(string format) {
            return ToString(format, CultureInfo.CurrentCulture);
          }
    
          public override string ToString() {
            return Gebruikersnaam;
          }
        }

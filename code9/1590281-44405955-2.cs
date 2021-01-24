    public static partial class DateTimeExtensions {
      public static DateTime AddYearsUp(this DateTime value, int amount) {
        // Business as usual: neither days are leap days or both days are leap days
        if (value.Month != 2 || value.Day != 29 || DateTime.IsLeapYear(value.Year + amount))
          return value.AddYears(amount);
    
        // We want 29 Feb to be turned into 1 Mar (not 28 Feb)
        return new DateTime(value.Year + amount, 3, 1, 
                            value.Hour, value.Minute, value.Second, value.Millisecond);
      }
    }
    

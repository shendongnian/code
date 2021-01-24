      public static class DateTimeExtensions {
        public static DateTime AddYearsUp(this DateTime value, int amount) {
          if (value.Month != 2 || value.Day != 29 || DateTime.IsLeapYear(value.Year + amount))
            return value.AddYears(amount);
    
          return new DateTime(value.Year + amount, 3, 1, value.Hour,
                              value.Minute, value.Second, value.Millisecond);
        }
      }
    
    ...
    
      var result = birthDay.AddYearsUp(18); 

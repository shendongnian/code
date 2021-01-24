    public static string STR(object value, long totalLen = 0, long decimals = 0) {
      string result = string.Empty;
      try {
        if (value is string) {
          return (string)value;
        }
        var originalDecimals = decimals;
        int currentLen = (int)totalLen + 1;
        while (currentLen > totalLen) {
          string formatString = "{0:N";
          formatString += decimals.ToString();
          formatString += "}";
          result = string.Format(formatString, value);
          if (result.StartsWith("0") && result.Length > 1 && totalLen - decimals <= 1) {
            // STR(0.5, 3, 2) --> ".50"
            result = result.Remove(0, 1);
          }
          else if (result.StartsWith("-0") && result.Length > 2 && totalLen - decimals <= 2) {
            // STR(-0.5, 3, 2) --> "-.5"
            result = result.Remove(1, 1);
          }
          if (totalLen > 0&& result.Length < totalLen && (decimals == originalDecimals || decimals == 0)) {
            // STR(20, 3, 2) --> " 20"
            result = result.PadLeft((int)totalLen);
          }
          currentLen = result.Length;
          if (currentLen > totalLen) {
            decimals--;
            if (decimals < 0) {
              result = string.Empty.PadRight((int)totalLen, '*');
              break;
            }
          }
        }
        return result;
      }
      catch {
        result = "***";
      }
      return result;
    }

      private static bool HasWildCard(IEnumerable<String> data, String wildCard) {  
        string pattern = Regex.Escape(wildCard).Replace(@"\*", ".*").Replace(@"\?", ".");
        return data.Any(item => Regex.IsMatch(item, pattern));
      }
      ...
      String[] test = new String[] {
        "Atlanta Hawks are bad this year!",
        "Detroit Tigers are okay this year!",
        "New England Patriots are good this year!"
      }
      bool result = HasWildCard(test, "Atlanta* *are great this year!");

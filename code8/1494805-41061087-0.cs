    public static string Test(string str) {
      // public methods should validate their values
      if (string.IsNullOrEmpty(str))
        return null;
      var match = Regex.Match(str, "[0-9]+(KG)|(ML)[0-9]*");
      return match.Success ? match.Value : null;
    }

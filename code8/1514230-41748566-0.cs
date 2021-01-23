    private static Regex _parser = new Regex(@"(0x)?((\d{2})+)h?", RegexOptions.Compiled);
    public static string AppendHexSuffix(this object hexNumber)
    {
      var hexString = Convert.ToString(hexNumber);
      var match = _parser.Match(hexString);
      if (!match.Success)
    	throw new FormatException("Object cannot be converted to a hex format");
      return match.Groups[2].Value + "h";
    }
    
    #if DEBUG
    public static void AppendHexSuffixTest()
    {
      AppendHexSuffixTest("0x121212", "121212h");
      AppendHexSuffixTest("0x121212h", "121212h");
      AppendHexSuffixTest("121212h", "121212h");
    }
    
    public static void AppendHexSuffixTest(object test, string expected)
    {
      if (test.AppendHexSuffix() != expected)
    	throw new Exception("Unit test failed");
    }
    #endif 

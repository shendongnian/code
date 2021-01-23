      private static string RemoveRecord(string source, string name) {
        string pattern = @"(?<!\w)" + Regex.Escape(name) + "=[0-9a-zA-Z]*;";
        return Regex.Replace(source, pattern, "");
      }
      ...
      string final = RemoveRecord("Key=abc;arg=pqr;lock=100;timeout=1;", "arg");

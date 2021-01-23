      // The pattern, you probably are looking for:
      string pattern = @"^[A-Za-z]+([A-Za-z0-9 ]*[A-Za-z0-9])*$";
      string[] tests = new string[] {
        // your test cases (valid strings)
        "Mazhar", "mazhar123", "mazhar khan1",
        // your test cases (invalid strings)
        "1233444", "@@@@@@",  "Mazhar@kkk",
        // my test cases (leading space, trailing space, double space, starts with digit)
        " Mazhar", "Mazhar ", "Mazhar    123", "123Mazhar"
      };
      var report = tests
        .Select(item => Regex.IsMatch(item, pattern)
          ? $"{item,15} is valid"
          : $"{item,15} is NOT valid");
      Console.Write(string.Join(Environment.NewLine, report));

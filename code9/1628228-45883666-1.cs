      using System.Text.RegularExpressions;
      ...
      string OriginalText = "Hello my name is <!name!> and I am <!age!> years old";
      Dictionary<string, string> substitutes = 
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) {
          { "name", "John" },
          { "age", "108"},
        };
      string result = Regex
        .Replace(OriginalText, 
                 @"<!([A-Za-z0-9]+)!>", // let placeholder contain letter and digits
                 match => substitutes[match.Groups[1].Value]);
      Console.WriteLine(result);

      using System.Text.RegularExpressions;
      ...
      string animals = "cat98dog75";
      string[] items = Regex
        .Matches(animals, "[a-zA-Z]+[0-9]*")
        .OfType<Match>()
        .Select(match => match.Value)
        .ToArray();
      string a = items[0];
      string b = items[1];
      Concole.Write(string.Join(", ", items));

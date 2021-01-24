      using System.Linq;
      using System.Text.RegularExpressions;
      ... 
      string line = "21 A 22 B 23 C 31 D 32 E 31 F 32 G 21 H 21 I 22 J";
      var result = Regex
        .Matches(line, "21 .*?((?=21 )|$)")
        .OfType<Match>()
        .Select(match => match.Value)
        .ToArray(); // <- let's materialize as na array
      Console.Write(string.Join(Environment.NewLine, result));

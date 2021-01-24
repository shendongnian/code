      using System.Linq;
      using System.Text.RegularExpressions;
      .. 
      string source = "S1 \t = F  A1 = T  A2 = T  F3 = F";
      string[] result = Regex
        .Matches(source, @"[A-Za-z][A-Za-z0-9]*\s*=\s*[TF]")
        .OfType<Match>()
        .Select(match => string.Concat(match.Value.Where(c => !char.IsWhiteSpace(c))))
        .ToArray();
      Console.WriteLine(string.Join(Environment.NewLine, result));

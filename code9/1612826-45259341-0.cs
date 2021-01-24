    using System.Text.RegularExpressions;
    string source = "John Due was drawing the quick brown fox. Alex King draws a fox";
    string pattern = @"([A-Z][a-z]+(\s[A-Z][a-z]+)*)|([a-z]+)";
    var result = Regex
      .Matches(source, pattern)
      .OfType<Match>()
      .Select(match => match.Value);
    Console.Write(string.Join("; ", result)); 

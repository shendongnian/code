    public class Example
    {
       public static void Main()
       {
          string pattern = @"\{(.+?)\|(.+?)\}";
          string input = "{TheKey|TheValue}{AnotherKey|AnotherValue}";
          MatchCollection matches = Regex.Matches(input, pattern);
          foreach (Match match in matches)
          {
             Console.WriteLine("The Key: {0}", match.Groups[1].Value);
             Console.WriteLine("The Value: {0}", match.Groups[2].Value);
             Console.WriteLine();
          }
          Console.WriteLine();
       }
    }

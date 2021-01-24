    public class Program
    {
       private static void Main(string[] args)
       {
    
          var input = "abcdef21KD-0815xyz429569468949489694694689ghijk";
          var regex = new Regex(@"(?<=KD-)\d+");
          var match = regex.Match(input);
    
          if (match.Success)
          {
             Console.WriteLine(match.Value);
          }
    
          // Or to match multiple times
          input = "abcdef21KD-0815xyz429569468949489694694689ghijk, KD-234dsfsdfdsf";
          var matches = regex.Matches(input);
    
          foreach (var matchValue in matches)
          {
             Console.WriteLine(matchValue);
          }
       }
    }

    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
       public static void Main()
       {
          string sContent = "1,3,5,14-10,15-20";       
    
          MatchEvaluator evaluator = new MatchEvaluator(LowerThan);
     
          Console.WriteLine(Regex.Replace(sContent, @"(\d+)-(\d+)", evaluator));
       }
    
       public static string LowerThan(Match match)
       {
          if (int.Parse(match.Groups[1].Value) > int.Parse(match.Groups[2].Value)) {
             return match.Groups[2].Value + "-" + match.Groups[1].Value;
          }
          return match.Value;
       }
    }

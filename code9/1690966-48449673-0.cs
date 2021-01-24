    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?<=""defaultWatchCount""\s*:\s*)\d+";
            string input = @""":true,""itemId"":""202190176821"",""defaultWatchCount"":23,""isUserSignedIn"":true,""isItemEnded""";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine(m.Value);
            }
        }
    }

    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"Input(.*)Logic(.*)Output(.*)";
            string input = @"Input
    {
       {input is here}
    }
    Logic{
       logic is here
    }
    
    
    
    
    
    Output{
       output is here
    }";
            RegexOptions options = RegexOptions.Singleline;
            
            Match match = Regex.Match(input, pattern, options);
            Console.WriteLine("'{0}' found at index {1}", m.Value, m.Index);
        }
    }

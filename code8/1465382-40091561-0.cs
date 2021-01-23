     class Program
        {
            static void Main(string[] args)
            {
    
                string[] Value = new string[] {
     "abc 1",
    "abc def 1",
    "abc-def 1",
    "abc 1b",
    "abc 11 b3",
    "abc 11 3",
    "abc 11b"
                };
    
    
                foreach (string value in Value)
                {
                    Match match = Regex.Match(value, @"^([A-Za-z-]+) (\d+)");
                    if (match.Success)
                    {
                        var word = match.Groups[1].Value;
                        var num = match.Groups[2].Value;
                        Console.WriteLine(word + " " + num);
                    }
                }
    
            }
        }
    
    
    //abc 1
    //abc-def 1
    //abc 1
    //abc 11
    //abc 11
    //abc 11

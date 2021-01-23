    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    static void Main(string[] args)
    {
        string string1 = "<body style=\"HEIGHT: 218px; margin: 0px; background-color: #ffffff;\" jQuery111105496473080628138=\"10\">";
        string string2 = "<body jQuery111105496473080628138=\"10\" style=\"HEIGHT: 218px; margin: 0px; background-color: #ffffff;\" >";
        string string3 = "<test style=\"HEIGHT: 218px; margin: 0px; background-color: #ffffff;\" jQuery111105496473080628138=\"10\">";
        List<string> theList = new List<string> { string1, string2, string3 };
    
        Regex heightMatchingRegex = new Regex("(HEIGHT:\\s*\\d{1,}[^;]*;)(?<=<body.*style=\"[^\"]*)(?=[^\"].*\"\\s*>)");
    
        foreach (string item in theList)
        {
            if (heightMatchingRegex.IsMatch(item))
            {
                Console.WriteLine("The match: " + heightMatchingRegex.Match(item));
                Console.WriteLine("Original: " + item);
                Console.WriteLine("Modified: " + heightMatchingRegex.Replace(item, ""));
            }
        }
    
        Console.ReadLine();
    }

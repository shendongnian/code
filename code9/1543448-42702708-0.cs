    using System.Text.RegularExpressions;
    
    string input = "Hello Wolrd";
    input = input.ToUpper();
    input = Regex.Replace(input, "[A-G]", "1");
    input = Regex.Replace(input, "[H-Q]", "2");
    input = Regex.Replace(input, "[R-Z]", "3");

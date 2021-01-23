    using System.Text.RegularExpressions; //on the top
    string regexPattern = "^[0-9]+$";
    string testString = "123456";
    
    if (Regex.IsMatch(testString, regexPattern))
    {
        Console.WriteLine("String contains only digits and is valid");
    }
    else
    {
        Console.WriteLine("String contains symbols other than digits or is empty");
    }

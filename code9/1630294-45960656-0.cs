    string regex = "^.{0,7}abc";
    
    System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(regex);
    string Value1 = "sssddabcgghh";
    
    Console.WriteLine(reg.Match(Value1).Success);

    // original value
    //string text = System.IO.File.ReadAllText(@"4'-8"x5/16"x20'-8 13/16"); This needs to be a filepath.
    string text = @"4'-8x5/16x20'-8 13/16";
    
    string path = text.Replace("'", "*12").Replace("-", "+").Replace("x", "+").Replace(" ", "+").Replace(@"""", "");
    System.Console.WriteLine("The original string: '{0}'", text);
    System.Console.WriteLine("The final string: '{0}'", path);
    
    Expression e = new Expression(path)
    Console.WriteLine(e.Evaluate);

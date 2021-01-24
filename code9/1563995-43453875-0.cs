    // original value
    string text = System.IO.File.ReadAllText(@"4'-8"x5/16"x20'-8 13/16");
    
    string path = text.Replace("'", "*12").Replace("-", "+").Replace("x", "+").Replace(" ", "+").Replace(@"""", "");
    System.Console.WriteLine("The original string: '{0}'", text);
    System.Console.WriteLine("The final string: '{0}'", path);
    
    Console.WriteLine();
    
    decimal d = decimal.Parse(path, CultureInfo.InvariantCulture);
    Console.WriteLine(d.ToString(CultureInfo.InvariantCulture));
    
    // after converting got this value in debug
    //'4*12+8+5/16+20*12+8+13/16
    
    Expression e = new Expression(path)
    Console.WriteLine(e.Evaluate);

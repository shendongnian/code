    string choice1=null; //casing of variable names
    while (true)
    {
        var key = System.Console.ReadKey(true);
        if (key.Key == ConsoleKey.Enter)
            break;
        choice1 += key.KeyChar;
     } 

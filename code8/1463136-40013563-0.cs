    int x;
    int y;
    Console.WriteLine("Welcome to my calculator program!");
    Console.WriteLine("This calculator for now can only do + and -");
    Console.WriteLine("If x is highter than y it will do - and if x is lower than y it will do +");
        
    Console.WriteLine("pls write in you x");
    x = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("pls write in your y");
    y = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("insert operator");
    string o = Console.ReadLine();
    
    if (o=="-")
    {
        Console.WriteLine("you chose to use minus");
        int sum = x - y;
        Console.WriteLine("result: {0}", sum);
        Console.WriteLine("Press a key to exit");
        Console.ReadLine();
    }
    else if (o=="+")
    {
        Console.WriteLine("you chose to use plus");
        int sum1 = x + y;
        Console.WriteLine("result: {0}", sum1);
        Console.WriteLine("Press a key to exit");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("the operator is not recognized");
    }

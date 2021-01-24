    var userIn = Console.Readline();
    var number = 0;
    if (!Int.TryParse(userIn, out number)){
        Exit;
    }
    if (number < LowNum || number > highNum)
    {
        Console.WriteLine("That is an invalid number, try entering a number between 1 and 12");
    }
    else 
    {
        Console.WriteLine("That is a valid number for a month");
    }
    Console.ReadLine();

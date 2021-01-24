        int UnterGrenze=0;
        int UberGrenze=0;
        Console.Write("UnterGrenze:");
        while (!int.TryParse(Console.ReadLine(), out UnterGrenze))
        {
            Console.WriteLine("Nur Integer Zahl bitte");
            Console.Write("UnterGrenze:");
        }
        Console.Write("UberGrenze:");
        while (!int.TryParse(Console.ReadLine(), out UberGrenze))
        {
            Console.WriteLine("Nur Integer Zahl bitte");
            Console.Write("UberGrenze:");
        }
        

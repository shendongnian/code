        ConsoleKeyInfo keyinfo;
        Console.ReadKey();
        while (!(Console.KeyAvailable  ))
        {
            keyinfo = Console.ReadKey();
            if (char.IsLetter(Console.ReadKey().KeyChar))
            {  
            }
        }

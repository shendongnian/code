    static void GetResponse()
    {
        Console.WriteLine("Do you wish to continue? [Y/N]");
    
        var keyInfo = Console.ReadKey(); //Read a single key from the user. The ReadKey method displays the pressed key on the console.
    
        //Check the pressed key and if it's not y or n, re-ask for it.
        while (keyInfo.KeyChar.ToString().ToLower() != "y" && keyInfo.KeyChar.ToString().ToLower() != "n")
        {
            Console.WriteLine();
            Console.WriteLine("Invalid choice. Valid choices are: Y or N");
            keyInfo = Console.ReadKey(); //Retake the input.
    
        }
        Console.WriteLine(); //For formatting purposes.
    }

    Console.WriteLine("Listening for the BIG BUTTON:......... ");
    ConsoleKeyInfo name = Console.ReadKey();
    Console.WriteLine("You pressed {0}", name.KeyChar);
    if(name.Key == ConsoleKey.Spacebar )
    {
        Console.WriteLine("Space key was pressed");
    }

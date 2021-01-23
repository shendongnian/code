    private char GetLetter()
    {
        while (true)
        {
            Console.WriteLine("Please input a letter.");
            var character = Console.ReadKey().KeyChar;
            if (char.IsLetter(character))
                return character;
        }
    }

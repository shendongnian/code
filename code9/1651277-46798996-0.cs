        Console.WriteLine("Please input the score of game 1: ");
        List<int> scores = new List<int>();
        int game1 = int.Parse(Console.ReadLine());
        scores.Add(game1);
        Console.WriteLine("Would you like to add more scores? Press 'n' to continue to averaging, press any other key to continue!");
        string playagain = Console.ReadLine();
        while(playagain != "n")
        {
            Console.WriteLine("Please input the score of next game: ");
            scores.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine("Would you like to add more scores? Press 'n' to continue to averaging, press any other key to continue!");
            playagain = Console.ReadLine();
        }
        Console.WriteLine("Total is " + scores.Sum());
        Console.WriteLine("Average is " + scores.Average());
        Console.Clear();

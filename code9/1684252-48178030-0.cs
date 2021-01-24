    static void Main(string[] args)
    {
        var levelSelected = false;
        var answer = 0;
        Console.WriteLine("What is your name?");
      
        string name = Console.ReadLine();
        Console.WriteLine($"{name}, there are 4 skill levels in this game:");
        Console.WriteLine("1. Advanced");
        Console.WriteLine("2. Experienced");
        Console.WriteLine("3. Average");
        Console.WriteLine("4. Novice");
        while (!levelSelected)
        {
            Console.WriteLine("Which skill level do you choose?");
            answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    Console.WriteLine($"Thank you {name}, you have choosen level {answer}");
                    Console.WriteLine("Is this what you want? (y/n)");
                    levelSelected = Console.ReadLine() == "y";
                    break;
                default:
                    Console.WriteLine($"Sorry {name} you should choose between 1 and 4:");
                    break;
            }
        }
        Console.WriteLine($"Good {name} you have chosen level {answer} you can now start the game!");         
        var x = Console.ReadLine();
    }

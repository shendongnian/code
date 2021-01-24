        Random random = new Random();
        int x =  random.Next(0, 11);
        Console.WriteLine("Guess a number betweeen 1 and 10");
        // create a counter for the total total guessed answers.
        int totalQuessed= 0;
        while (true)
        {
            int y = int.Parse(Console.ReadLine());
            if (y > x)
            {
                Console.WriteLine($"You guessed high !");
            }
            if (y < x)
            {
                Console.WriteLine("You guessed low !");
            }
            if (y == x)
            {
                Console.WriteLine("You guessed right !");
                Console.ReadLine();
                break;
            }
          // increase by one
          totalQuessed++;
          Console.WriteLine("You've guessed: {0} times",totalQuessed);
        }

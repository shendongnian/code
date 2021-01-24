    Random rnd = new Random();
    int randomnumber = rnd.Next(1, 100);
    int allowed_attemps = 5;
    while (allowed_attemps > 0)
    {
        //PC tells user to pick a number, display guessed number
        Console.Write("Guess any integer between 1 and 100: ");
        string input = Console.ReadLine();
        int userentry = Convert.ToInt32(input);
        if (userentry > randomnumber)
        {
            Console.WriteLine($"You entered {userentry}. That's too  high.Try again.");
        }
        else if (userentry < randomnumber)
        {
            Console.WriteLine($"You entered {userentry}. That's too low .Try again.");
        }
        else
        {
            Console.WriteLine($"You entered {userentry}. That's right.Good job.");
            break;
        }
        allowed_attemps--;
    }

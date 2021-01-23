    static bool PlayGame ()
    {
        int number = new Random().Next(1, 10);
        var userWon = false;
        Console.WriteLine("Secret Number is between 1 and 10. ");
        for (var numOfAttempts = 10; numOfAttempts > 0; numOfAttempts--)
        {
            Console.WriteLine($"Guess the secret number you only have {numOfAttempts} attempts!");
            var guess = Convert.ToInt32(Console.ReadLine());
            if (guess == number)
            {
                userWon = true;
                break;
            }
            Console.WriteLine("Incorrect! Try again");
        }
        if (userWon)
            Console.WriteLine("WoW! You got it! Well done!");
        else
            Console.WriteLine("Sorry you lost =(");
        Console.WriteLine("Try Again? Y/N");
        var answer = Console.ReadLine();
        return answer.ToLower() == "y";
    }

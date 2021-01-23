        bool run = true;
        int maxTrys=20;
        Random random = new Random();
        
        while (run)
        {
        	int rnd=random.Next(1, 101);
       
        	Console.WriteLine("Can you guess my number? I am thinking about a number between 1 and 100!");
        	int trys=0;
        	bool solved=false;
        	while (!solved && trys<maxTrys)
        	{
        		trys++;
        	    int guess;
        	    bool numericGuess;
        	    do {
            		numericGuess=int.TryParse(Console.ReadLine(), out guess);
            		if (!numericGuess) {
            		    Console.WriteLine("Please enter a number");
            		}
        	    } while (!numericGuess);
                
        		if (guess > rnd)
        		{
        			Console.WriteLine(string.Format("My number is lower than {0}\n guess again >>", guess));
        		}
        		else if (guess < rnd)
        		{
        			Console.WriteLine(string.Format("My number is higher than {0}\n guess again >>", guess));
        		}
        		else if (guess == rnd)
        		{
        			solved=true;
        			Console.WriteLine(string.Format("You guessed right my number is {0} and you needed {1} trys", rnd, trys));
        		}
        	}
        	if (!solved) {
        		Console.Clear();
        		Console.WriteLine(string.Format("You only have {0} trys. You failed! \n", maxTrys));
        	}
        	
        	Console.WriteLine("Do you wanna play again? Press R + Enter to play again!");
        	string rerun = Console.ReadLine().ToUpper();
        
        	if (!rerun.Equals("R"))
        	{
        		run = false;
        	}
        }
        Console.Clear();
        Console.WriteLine("Thanks for playing see you next time!");
        Console.ReadLine();    

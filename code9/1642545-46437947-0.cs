        int number = 4;
		int guesscount = 0;
		int guess = 0;
		Console.WriteLine("Guess a number between 1 and 10: ");    
		guess = Convert.ToInt32(Console.ReadLine());
		
		while(number != guess){
			if(guess < number)
				Console.WriteLine("Your guess is too low");
			else
				Console.WriteLine("Your guess is too high");
			
			Console.WriteLine("Guess again: ");
			guesscount = guesscount + 1;
    		guess = Convert.ToInt32(Console.ReadLine());
		}
		
		Console.WriteLine("You got it!!!!");

	public void TryToGuessMultiplication_GameStep(int num1, int num2)
	{
				Console.WriteLine("Whats " + num1 + " times " + num2 + "?");
	
				var answer = Convert.ToInt32(Console.ReadLine());
	
				if ( answer == num1 * num2) {
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Thats the correct answer!");
				    ++score; // Gives score
				} else {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Bummer, try again!");
				}
				Console.ResetColor();
				Console.WriteLine("Your score: " + score);
	}

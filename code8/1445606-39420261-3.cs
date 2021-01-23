	public void TryToGuessMultiplication_GameStep(int num1, int num2)
	{
				Console.WriteLine("Whats " + num1 + " times " + num2 + "?");
	
				var answer = Convert.ToInt32(Console.ReadLine());
	
				if ( answer == num1 * num2) {
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Thats the correct answer!");
				} else {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Bummer, try again!");
				}
				Console.ResetColor();
				++score; // Gives score
				Console.WriteLine("Your score: " + score);
	}

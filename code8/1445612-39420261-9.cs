    public void PrintUserMessage(ConsoleColor color, string message)
    {
    		Console.ForegroundColor = color;
    		Console.WriteLine(message);
    }
	public void TryToGuessMultiplication_GameStep(int num1, int num2)
	{
				Console.WriteLine("Whats " + num1 + " times " + num2 + "?");
	
				var answer = Convert.ToInt32(Console.ReadLine());
	
				if ( answer == num1 * num2){
					PrintUserMessage( ConsoleColor.Green, "Thats the correct answer!");
					++score; // Gives score
				}else
					PrintUserMessage( ConsoleColor.Red,"Bummer, try again!");
				
				Console.ResetColor();
				Console.WriteLine("Your score: " + score);
	}

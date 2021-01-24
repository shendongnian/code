       private static int GuessNumber() {
         Console.Write("\nGuess number: ");
         int result = 0; 
         // Check User Input: what if the inserted value is "bla-bla-bla"? 
         while (!int.TryParse(Console.ReadLine(), out result))         
           Console.WriteLine("Incorrect format; please, put an integer value");
         return result; 
       }
       private static void PlayGame(int value, int maxTries = 10) {
         List<int> InsertedNumbers = new List<int>();
         while (InsertedNumbers.Count < maxTries) {
           int guess = GuessNumber();
           InsertedNumbers.Add(guess);
           if (guess < value)
             Console.WriteLine($"No. My number is larger then {guess}"); 
           else if (guess > value)
             Console.WriteLine($"No. My number is smaller then {guess}");
           else {
             Console.WriteLine($"Bravo. You had {InsertedNumbers.Count} tries.");
             // Combine all items in InsertedNumbers into single string
             Console.WriteLine(string.Join(Environment.NewLine, InsertedNumbers));
             return;
           }
         }
         Console.WriteLine("\nYou tried maxTries times. Game is  over!");
       }

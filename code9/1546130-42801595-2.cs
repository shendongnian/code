    public static void printScreen() {
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("Guesses: ");
			Console.ResetColor();
			Console.WriteLine("{0}", safe.guesses);
			Console.WriteLine("");
			Console.WriteLine("     =================================    ");
			Console.WriteLine("     |       |       |       |       |    ");
			Console.WriteLine("     |       |       |       |       |    ");
			Console.WriteLine("     |   {0}   |   {1}   |   {2}   |   {3}   |    ", safe.cn1, safe.cn2, safe.cn3, safe.cn4);
			Console.WriteLine("     |       |       |       |       |    ");
			Console.WriteLine("     |       |       |       |       |    ");
			Console.WriteLine("     =================================    ");
			Console.WriteLine("");
			Console.WriteLine("Guess the first number of the combination.");
			Console.WriteLine("");
		}
		public static void Checking(ref int safeCN, int numberG) {
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("");
			Console.WriteLine("{0} Is Correct!", numberOf.puzzleGuess);
			Console.ResetColor();
			safeCN = numberG;
			safe.safeLocked = false;
			Console.ReadLine();
			Console.Write("Guesses: ");
			Console.ResetColor();
			Console.WriteLine("{0}", safe.guesses);
			Console.WriteLine("");
			safeCracking();
		}
		public static void safeCracking() {
			//First number
			Random rand = new Random();
			int num1 = rand.Next(1, 10);
			//Second number
			int num2 = rand.Next(1, 10);
			//Third number
			int num3 = rand.Next(1, 10);
			//Fourth number
			int num4 = rand.Next(1, 10);
			// this is the for loop
			for (int i = 0; i < 20; i++) {
				// check here if exceeded maximum trials
				if (safe.guesses == 20) {
					playerDeath();
				}
				// print the screen in each loop iteration
				printScreen();
				string numg = "";
				int numberG = 0;
				try{
				   numg = Console.ReadLine();
				   numberG = Int.Parse(numg);
				} catch {
				   numg = "";
				   numberG = 0;
				}
				numberOf.puzzleGuess = numg;
				//Check number 4
				if (safe.cn3 < 0 && (numg == num4.ToString())) {
					Checking(ref safe.cn4, numberG);
				}
				//Check number 3
				else if (safe.cn2 < 0 && (numg == num3.ToString())) {
					Checking(ref safe.cn3, numberG);
				}
				//Check number 2
				else if (safe.cn1 < 0 && (numg == num2.ToString())) {
					Checking(ref safe.cn2, numberG);
				}
				//Check number 1
				else if (safe.cn1 >= 0 && (numg == num1.ToString())) {
					Checking(ref safe.cn1, numberG);
				} else {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("");
					Console.WriteLine("{0} Is Incorrect!", numberOf.puzzleGuess);
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.WriteLine("Press Enter to continue...");
					Console.ResetColor();
					Console.ReadLine();
					safe.guesses++;
					safeCracking();
				}
			}
			if (safe.safeLocked = false) {
				//Continue game here...
			}
		}

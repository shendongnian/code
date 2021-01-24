		static void Main(string[] args) {
			string First; //You should use a char
			int score = 0;
			string Second;
			//TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
			Console.Write("Where is  the capital of the state of Florida? A.Orlando,B.Tallahassee, C. Miami, or D. Tampa");
			// Here is the while loop
			// While score is not 50 do stuff
			while (score!=50) {
			First = Console.ReadLine();
				score = checkanswer(First, "B", 50, score);
			}
			
			Console.Write("Where is Walt Disney World Park located in Florida? A.Orlando,B.Tallahassee, C. Miami, or D. Tampa");
			
			while (score != 100) { Second = Console.ReadLine();
				score = checkanswer(Second, "A", 50, score);
			}
		}
		// I added this little fancy function. It makes your program more structured and a little bit smaller ;)
		static int checkanswer(string userinput, string rightanswer, int winpoints, int score){
			if (userinput==rightanswer) {
				Console.WriteLine("You entered the wrong answer.\n");
				Console.WriteLine("Correct!\n" + " score:" + winpoints + score + "\n");
				return winpoints + score;
			} else {
				Console.WriteLine("You entered the wrong answer.\n");
				Console.WriteLine("Wrong!\n" + " score:" + score + "\n");
				return score;
			}
		}

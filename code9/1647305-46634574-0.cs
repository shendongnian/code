    using System;
    namespace Quiz
    {
	class MultipleChoiceQuiz
	{
		static int correct = 0; // this will hold the correct answers
		static int questions = 0; // this will hold the amount of questions
		
		public static void CurrentQuestion(string correctAnswer)
		{
			questions++;//this will add 1 when CurrentQuestion is called
			do
			{
				string userAnswer = Console.ReadLine();
				if (userAnswer != "A" && userAnswer != "B" && userAnswer != "C" && userAnswer != "D")
				{
					Console.WriteLine("\nError - Not a Valid Input - Please Enter Valid Input");
				}
				else
				{
					if (userAnswer == correctAnswer)
					{
						Console.WriteLine("\nThat is correct!");
						correct++;//this will add 1 to correct when you answer correctly
						break;
					}
					else if (userAnswer != correctAnswer)
					{
						Console.WriteLine("\nSorry, that is incorrect.");
						break;
					}
				}
			}
			while (true);
		}
		public static void Questions()
		{
			Console.WriteLine("Chad Mitchell - ENGR 115 - USAF HC130J Power On Quiz\n");
			Console.WriteLine("Please enter your first name: ");
			string firstName = Console.ReadLine();
			Console.WriteLine("\nWelcome to the HC-130J Power-On Quiz " + firstName + ".\n");
			Console.WriteLine("Using the keyboard, please submit answers by using the \'ENTER\' key.\n");
			Console.WriteLine("Please submit answers in CAPITAL letter form only.\n");
			Console.WriteLine("Ready to begin " + firstName + "? Hit the \'ENTER\' key now...");
			Console.ReadLine();
			Console.Clear();
	
			//Question 1
			Console.WriteLine("Chad Mitchell - ENGR 115 - USAF HC130J Power On Quiz\n");
			Console.WriteLine("Question 1 - What position does the ramp contol knob need to be in? " +
							"\n\nA. 3N \nB. 1 \nC. 6N \nD. A or C \n\nWhat is your answer " + firstName + "?");
			CurrentQuestion("D");
			Console.Write("\nPress \'ENTER\' to continue...");
			Console.ReadLine();
			Console.Clear();
	
			//Question 2
			Console.WriteLine("Chad Mitchell - ENGR 115 - USAF HC130J Power On Quiz\n");
			Console.WriteLine("Question 2 - After power is applied to the aircraft, the battery needs to be turned off? " +
							"\n\nA. True \nB. False \n\nWhat is your answer " + firstName + "?");
			CurrentQuestion("A");
			Console.Write("\n");
			Console.Write("\nPress \'ENTER\' to continue...");
			Console.ReadLine();
			Console.Clear();
	
			//Question 3
			Console.WriteLine("Chad Mitchell - ENGR 115 - USAF HC130J Power On Quiz\n");
			Console.WriteLine("Question 3 - Above what temperature does air condition need to be applied to the aircraft while power is applied? " +
							"\n\nA. 75 degrees Fahrenheit \nB. 100 degrees Fahrenheit \nC. 95 degrees Fahrenheit \nD. 85 degrees Fahrenheit \n\nWhat is your answer " 
							+ firstName + "?");
			CurrentQuestion("C");
			Console.Write("\n");
			Console.Write("\nPress \'ENTER\' to continue...");
			Console.ReadLine();
			Console.Clear();
			
			//Score
			Console.WriteLine("You got " + correct + " out of " + questions + " correctly!");
		}
	}
    }

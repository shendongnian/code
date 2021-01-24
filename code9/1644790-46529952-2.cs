	using System;
	using System.Collections.Generic;
						
	public class Program
	{
		private static int score = 0;
		private static string currentWord = string.Empty;
		private static char userGuess = '`';
		private static List<char> correctLetters = new List<char>();
		
		public static void Main()
		{
			currentWord = "are";
			
			do {
				Console.WriteLine("Enter a letter: ");
				userGuess = Console.ReadLine()[0];
			} while (TestInput());
			
			Console.WriteLine("The word was: " + currentWord);
			Console.ReadLine();
		}
		
		private static bool TestInput() {
			if (currentWord.ToLowerInvariant().Contains(userGuess.ToString().ToLowerInvariant())) {
				correctLetters.Add(userGuess);
				score++;
				Console.WriteLine("Current Score: " + score);
			}
			
			if (correctLetters.Count == currentWord.Length)
				return false;
						
			return true;
		}
	}

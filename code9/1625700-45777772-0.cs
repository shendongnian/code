    using System;
    
    namespace DeliverablePart1
    {
    	internal class DeliverablePart1
    	{
    		private static void Main(string[] args)
    		{
    			Console.WriteLine("Would you like to compare 2 numbers to see if their corresponding place is same total?");
    			var shouldContinue = Console.ReadLine();
    
    			if (shouldContinue != null && shouldContinue.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
    			{
    				var firstNum = GetIntFromUser("Please enter a three digit whole number");
    				var secondNum = GetIntFromUser("Please enter a three digit whole number");
    				var thirdNum = GetIntFromUser("Please enter a three digit whole number");
    
    				Console.WriteLine(Compare(firstNum, secondNum, thirdNum) ? "True" : "False");
    			}
    			else
    			{
    				Console.WriteLine("Exiting");
    			}
    
    			// waits for the user to press a key to exit the app, so that they can see their result
    			Console.ReadKey();
    		}
    
    		/// <summary>
    		/// Makes the user enter in a three digit number, and exits if they say "no"
    		/// </summary>
    		/// <param name="msg">The message prompt to ask for the integer</param>
    		/// <returns>System.Int32., or will exit</returns>
    		public static int GetIntFromUser(string msg)
    		{
    			while (true)
    			{
    				Console.WriteLine(msg);
    				var valFromUser = Console.ReadLine()?.Trim();
    
    				if (valFromUser != null)
    				{
    					int result;
    					if (int.TryParse(valFromUser.Trim(), out result) && valFromUser.Length == 3)
    					{
    						return result;
    					}
    					if (valFromUser.Equals("no", StringComparison.CurrentCultureIgnoreCase))
    					{
    						Console.WriteLine("Exiting.");
    						Environment.Exit(0);
    					}
    				}
    				Console.WriteLine("Hmm, that's not a three digit number. Try again.");
    			}
    		}
    
    		public static bool Compare(int a, int b, int c)
    		{
    			var lastDigitA = a % 10;
    			var lastDigitB = b % 10;
    			var sumStatic = lastDigitA + lastDigitB;
    
    			do
    			{
    				lastDigitA = a % 10;
    				lastDigitB = b % 10;
    				a = a / 10;
    				b = b / 10;
    				c--;
    				var sumCompare = lastDigitA + lastDigitB;
    
    				if (sumCompare != sumStatic)
    				{
    					return false;
    				}
    			} while (c != 0);
    			return true;
    		}
    	}
    }

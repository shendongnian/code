    using System;
        					
        public class Program
        {
        	public static void Main()
        	{
        		string randomInput = "Apple";
        		string userInput = "Eppleqq";
        		
        		
        		//Word lengths are not equal therefore user has lost already
        		if(randomInput.Length != userInput.Length){
        			Console.WriteLine("User has not guessed the word, your word is not the same size as the random one.");
        			return;
        		}
        		
        		
        		char[] randomCharArray = randomInput.ToLowerInvariant().ToCharArray();
        		char[] userInputArray = userInput.ToLowerInvariant().ToCharArray();
        		
        		int index = 0;
        		
        		for(int i = 0; i < randomCharArray.Length; i++)
        		{
        			if(randomCharArray[i] == userInputArray[i])
        				continue;
        			else{
        				Console.WriteLine("You have not guessed the word, keep trying!");
        				return;
        			}
        		}
        		
        		Console.WriteLine(string.Format("You have won!, you have guessed the word {0}",userInput));
        		
        	}
        
        }

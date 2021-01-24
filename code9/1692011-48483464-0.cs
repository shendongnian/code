    using System;
    					
    public class Program
    {
    	public static void Main(string[] args)
    	{
    	  Console.WriteLine("Welcome to the Caesarian Cipher program");
    	  Console.WriteLine("Please, enter a word.");
    	
    	  string word = Console.ReadLine();
    	
    	  char[] letters = word.ToCharArray(); //chops the string up into individual characters.
    	 			
    	  for(int i = 0; i < letters.Length; i++)
    	  {
 				var charAsInt=(int)letters[i];
   				var newChar= (char)(charAsInt+3);
  				
   				Console.Write(newChar);
			}   		
    	}
    }

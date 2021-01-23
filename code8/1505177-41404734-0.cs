    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		// To make this event better, make a list like this: List<int> numbers = new List<int>();
    		// write a do-while loop and tell the user to keep entering numbers and once they want to know the biggest,
    		// they can enter 'B'. Keep adding numbers to the list until the user enters 'B'. As soon as 'B' is entered, 
    		// then send the list to GetBiggest like this: int biggest = GetBiggest(numbers);
    		int num1, num2, num3;
    		Console.WriteLine("First number");
                num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Second number");
                num2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Third number");
                num3 = int.Parse(Console.ReadLine());
    		Calculator calculator = new Calculator();
    		int biggest = calculator.GetBiggest(num1, num2, num3);
            Console.WriteLine("Biggest number is " + biggest);
            Console.ReadLine();
    	}
    }
    
    public class Calculator
    {
    	// To make this method even better, send the list here like this: internal int GetBiggest(List<int> numbers)
    	internal int GetBiggest(int num1, int num2, int num3)
    	{
    	  	if (num1 > num2 & num1 > num3)
    		{
    			// You do not need to do any more checks, you know this is the biggest so return and leave this method
    			return num1;
    		}
    		
    		// You do not need else here because if num1 was biggest you would have returned.
    		// You are here because num1 is not biggest
    		if (num2 > num1 & num2 > num3)
    		{
    			return num2;
    		}
    		
    		// I will let you do this one
    	}
    }

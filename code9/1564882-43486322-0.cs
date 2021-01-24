    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Console;
    
    class PaintingEstimate
    {
        static void Main()
        {
            string[] input = new string[2];
    
    		Write("\n   Type a room length in feet >> ");
    		input[0] = ReadLine();
    		Write("\n   Type a room width in feet >> ");
    		input[1] = ReadLine();
    
    		decimal endEstimate =PaintJobCalc((string[])input);
    
    		WriteLine("\n   Your Paint Job total will be ${0}", endEstimate);
    
    		ReadLine();
            
        }
    
        public static void PaintJobCalc(string[] input)
        {
            int inputOne = Convert.ToInt32(input[0]);
    		int inputTwo = Convert.ToInt32(input[1]);
    
    		var wallCount = (inputOne + inputTwo) * 2;
    		var squareFootage = wallCount * 9;
    		var endEstimate = squareFootage * 6;
    
    		return endEstimate;
    
    
        }
    }

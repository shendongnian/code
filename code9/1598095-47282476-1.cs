    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            
            string inputString = "Manoj# Bhard@waj";
    		//  . indicates any character to be removed. You can also write characters as well to remove some selected characters
            string outputString = Regex.Replace(input, ".", " ");
    
            // Write the output.
            Console.WriteLine(inputString);
            Console.WriteLine(outputString);
        }
    }

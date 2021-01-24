    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                //Your code goes here
                Console.WriteLine( RoundUp(124.25, 2));
            }
            public static double RoundUp(double input, int places)
    {
        double multiplier = input*2;
             double numberround  = Math.Round(multiplier, MidpointRounding.AwayFromZero)/2;
                
         return numberround;
    }
        }
    }

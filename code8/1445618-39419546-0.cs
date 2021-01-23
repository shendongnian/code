    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication1
    {
        class Program
        {
            float points = 0; 
            double output = 0;
            float minLevel = 2;
            int maxLevel = 100;
            int lvl = 0;
            void Main() //<-- Bad entry point public static void Main()
            {
            
                for (lvl = 1; lvl <= maxLevel; lvl++)
                {
                    points += (float)Math.Floor(lvl + 300 * Math.Pow(2, lvl / 7.)); // <-- You have to explicitly specify the mantissa if you have a '.' is should be 7.0 or 7f
                                //^--- You also need to cast to a float here because the expression evaluates to a double
                    if (lvl >= minLevel)
                        Console.WriteLine("Level " + (lvl) + " - " + output + " EXP");
                    output = Math.Floor(points / 4);
                }
            }
        }
    }

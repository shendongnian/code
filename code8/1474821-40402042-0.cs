    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MS_Test
    {
        class Program
        {
            static Rule[] Rules = new Rule[]
                {
                    new Rule(1000, "M"),
                    new Rule(900, "CM"),
                    new Rule(500, "D"),
                    new Rule(400, "CD"),
                    new Rule(100, "C"),
                    new Rule(90, "XC"),
                    new Rule(50, "L"),
                    new Rule(40, "XL"),
                    new Rule(10, "X"),
                    new Rule(9, "IX"),
                    new Rule(5, "V"),
                    new Rule(4, "IV"),
                    new Rule(1, "I"),
                };
            static void Main(string[] args)
            {
    
                Console.WriteLine("Roman Number First: ");
                string firstNumber = Console.ReadLine();
    
                Console.WriteLine("Roman Number Second: ");
                string secondNumber = Console.ReadLine();
    
                int result = RomanToInteger(firstNumber) + RomanToInteger(secondNumber);
    
                Console.WriteLine(Romanise(result));
                Console.ReadLine();
    
    
    
            }
    
            private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };
    
            public static int RomanToInteger(string roman)
            {
                int number = 0;
                for (int i = 0; i < roman.Length; i++)
                {
                    if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                    {
                        number -= RomanMap[roman[i]];
                    }
                    else
                    {
                        number += RomanMap[roman[i]];
                    }
                }
                return number;
            }
    
            private static string Romanise(int n)
            {
                if (n == 0) return ""; // Recursion termination
    
                foreach (var rule in Rules) // Rules are in descending order
                    if (rule.N <= n)
                        return rule.Symbol + Romanise(n - rule.N); // Recurse 
    
                // If this line is reached then n < 0
                throw new ArgumentOutOfRangeException("n must be greater than or equal to 0");
            }
    
            // Represents a substitution rule for a roman-numerals like numerical system
            // Number 'N' is equivilant to string 'Symbol' in the system.
            class Rule
            {
                public int N { get; set; }
                public string Symbol { get; set; }
                public Rule(int n, string symbol)
                {
                    N = n;
                    Symbol = symbol;
                }
            }
        }
    }

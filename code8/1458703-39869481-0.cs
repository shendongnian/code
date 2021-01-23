    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string formula = "=SUM(R[-3]C[-1];R[-3]C;R[-3]C[2];R[-1]C[2]:R[1]C[3];RC[-1])";
                string pattern = @"=?(R\[([-0-9]*)\]|RC)";
                System.Text.RegularExpressions.Regex parser = new System.Text.RegularExpressions.Regex(pattern);
                System.Text.RegularExpressions.MatchCollection matches;
    
                // parse formula
                matches = parser.Matches(formula);
    
                // iterate results
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    if (match.Groups[0].Value == "RC")
                    {
                        Console.WriteLine("0");
                    } else {
                        Console.WriteLine(match.Groups[2].Value);
                    }
                }
                Console.ReadKey();
    
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.IO;
    
        class Program
        {
            static void Main()
            {
                // Input string.
                string mixedCase = "heLLoWorLd";
        
                // Call ToLower instance method, which returns a new copy.
                string lower = "";
                string uper = "";
                for (int i = 0; i < mixedCase.Length; i++)
                {
                    if (char.IsLower(mixedCase[i]))
                        lower = lower + mixedCase[i];
                    else
                        uper = uper + mixedCase[i];
                }
        
                // Display results.
                Console.WriteLine("{0}{1}",
                    lower,
                    uper);
            }
        }

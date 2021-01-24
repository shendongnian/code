    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace ConsoleApp6
    {
        class Program
        {
            static void Main(string[] args)
            {
                long N, i, answer = 1;
                N = Convert.ToInt32(Console.ReadLine());
    
                var A = Console.ReadLine() // Read the line of space delimited numbers
                    .Split(' ') // Split out by the separator
                    .Select(n => Convert.ToInt64(n)) // Parse each number to long
                    .ToArray(); // Convert to a materialized array
    
                Debug.Assert(A.Length == N, "Site lied to us about N numbers");
    
                for(i = 0; i < N; i++)
                {
                    answer = (answer * A[i]) % (1000000007);
                }
    
                Console.WriteLine(answer);
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace primeCsharp
    {
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;   // Number to be test for prime-ness
            int i = 2;   // Loop counter
            bool is_prime = true;   // Boolean flag...
                                    // Assume true for now
            Console.WriteLine("Enter a number and press ENTER: ");
            n = Console.Read();
            // Test for a prime number by checking for divisiblity
            // by all whole numbers from 2 to sqrt(n).
            while (i <= Math.Sqrt(n))
            {
                if (n % i == 0)
                {   // If i divides n, 
                    is_prime = false; // n ix not prime
                    break;     // BREAK OUT OF THE LOOP NOW!
                }
                ++i;
            }
            // Print results
            if (is_prime)
            {
                Console.WriteLine("Number is prime.\n");
            }
            else
            {
                Console.WriteLine("Number is not prime.\n");
            }
        }
     }
    }

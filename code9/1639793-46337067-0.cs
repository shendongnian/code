    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    
    namespace Prime_number
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[,] k = isPrimeSet(1, 1);
                Console.Read();
            }
    
            public static int[,] isPrimeSet(int a, int b)
            {
                int[,] primeNumArray; // Prime Multi Array 1000 slots in each array
                ArrayList primeA = new ArrayList(); // All prime numbers a 1 to 1000
                ArrayList primeB = new ArrayList(); // All prime numbers b 1 to 1000
                
                ArrayList dumpArrayA = new ArrayList(); // None prime numbers
                ArrayList dumpArrayB = new ArrayList(); // None prime numbers
                int i = 0;
                int m = 0;
                int j = 0; // Index of primeB
                int n = 0;
    
                for (a = 1; a <= 1000; a++) // Adds all prime numbers 1 through 1000 to primA[];
                {
                    if (isPrime(a) == true)
                    {
                        // Index of primeA
                        primeA.Add( a); // Add primes to a
                        i++;
                    }
                    else // Stores none prime numbers
                    {
                        dumpArrayA.Add(m);
                        m++;
                    }
                }
    
                for (b = 1; b <= 1000; b++) // Adds all prime number 1 through 1000 to primeB[];
                {
                    if (isPrime(b) == true)
                    {
                        primeB.Add(b); // Add primes to b
                        j++;
                    }
                    else
                    {
                        dumpArrayB.Add(n);
                        n++;
                    }
    
                }
                primeNumArray= new int[primeA.Count,2];
                // Merge primesA[] and primesB[];
                for (int k = 0; k < primeA.Count; k++)
                {
                    primeNumArray[k, 0] = (int)primeA[k];
                    primeNumArray[k, 1] = (int)primeB[k];
                }
    
                // Print Contents of PrimeNumArray
                for (int l = 0; l <= primeNumArray.GetLength(0)-1; l++)
                {
                    Console.WriteLine(primeNumArray[l, 0] + "  " + primeNumArray[l, 1]);
                }
    
                return primeNumArray;
    
            }
    
    
            static bool isPrime(int num)
            {
                bool bPrime = true;
                int factor = num / 2;
                int i = 0;
                for (i = 2; i <= factor; i++)
                {
                    if ((num % i) == 0)
    
                        bPrime = false;
                }
                return bPrime;
            }
        }
    }

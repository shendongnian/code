    using System;
    
    namespace Rextester { 
        public class Program { 
            public static void Main(string[] args) { 
                double sum = 0; 
                for(int i=1; i <= 10; i++) { 
                    sum += (i+1.0)/(i+2.0);  // 1.0 instead of 1 will tell the compiler to use floating point division.
                } 
                Console.WriteLine("{0}", sum); 
            } 
        } 
    }

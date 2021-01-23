    using System;
    using System.Collections;
    using System.Numerics;
    
    public class Test 
    {
        public static void Main(string[] args)
        {
            BigInteger a = 9123456789;
            BigInteger b = BigInteger.Pow(a, 9999);
    
            //Output this number if you're feeling lucky.
            Console.WriteLine(b);
        }
    }

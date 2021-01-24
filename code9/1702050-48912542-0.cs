    public class Customer : IEnumerable  {        
        public IEnumerator GetEnumerator()      {  throw new NotImplementedException(); }  }  
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Collections; 
    
    namespace TestDomain
    {
        class Program
        {
                public static void Main(String[] args)
                {
                    IEnumerable<int> Values = from value inEnumerable.Range(1, 10) select value;
    
                    foreach (int a in Values)
                    {
                        Console.WriteLine(a);
                    }
                    Console.ReadLine();
    
                 }
         }
    }

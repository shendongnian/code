    using System.IO;
    using System;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main(string[] args)
        {
            ListHolder List = new ListHolder();
            List.addNumber(6);
            List.addNumber(3);
            List.addNumber(2);
            List.returnNumbers();
            Console.ReadLine();
        }
    }
    
    class ListHolder
    {
        List<int> numbers = new List<int>();
    
        public void addNumber(int val)
        {
            numbers.Add(val);
        }
    
        public void returnNumbers()
        {
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
                //Console.ReadLine();
            }
        }
    }

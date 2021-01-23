    //Rextester.Program.Main is the entry point for your code. Don't change it.
    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    
    using System;
    using System.Collections.Generic;
    
    namespace Rextester
    {
        public class Program
        {
            public static Dictionary<long, MyStruct> myDictionary = new Dictionary<long, MyStruct>();
            
            public static void Main(string[] args)
            {
                myDictionary.Add(1, new MyStruct { Numbers = new List<int> { 1, 2} });
                Add(1, 3);
                
                // printing out the values
                foreach(KeyValuePair<long, MyStruct> number in myDictionary)
                {
                    Console.WriteLine("Key: {0}", number.Key);
                    Console.WriteLine("Values:");
                    for(var i = 0; i < number.Value.Numbers.Count; i++)
                    {
                        Console.WriteLine(number.Value.Numbers[i]);
                    }
                }
            }
            
            public static void Add(long key, int number)
            {
                if (myDictionary.ContainsKey(key))
                {
                    var myStruct = myDictionary[key];
                    if (myStruct.Numbers != null)
                    {
                        myStruct.Numbers.Add(number);
                    }
                }
                else
                {
                    myDictionary[key] = new MyStruct { Numbers = new List<int> { number }};
                }
            }
        }
        
        public struct MyStruct
        {
            public List<int> Numbers;
        }
    }

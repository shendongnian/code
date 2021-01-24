    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace YourNameSpace
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                ClassA Item = new ClassA();
                Item.PredeterminedValues();
                
                foreach(string s in Item.StringArray)
                {
                    Console.WriteLine(s);
                }
            }
        }
        
        public class ClassA
        {
            public int Counter {get;private set;}
            public string[] StringArray{get;private set;}
            
            public ClassA()
            {
                StringArray = new string[2];
            }
            
            public void Add(int Value)
            {
                Counter += Value;   
            }
            
            public void PredeterminedValues()
            {
                StringArray[0] = ("SomeString1");
                StringArray[1] = ("SomeString2");
            }
        }
    }

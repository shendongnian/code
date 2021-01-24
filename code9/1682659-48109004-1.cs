    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static List<string> data = new List<string>();
            public static void Main(string[] args)
            {
                //Your code goes here
               new Program().addelements();
               new Program().addelements();
                
               for(int i=0; i<data.Count;i++)
                Console.WriteLine(data[i]);
            }
            
            private  void addelements()
            {
               data.Add("Some string value");
            }
        }
    }

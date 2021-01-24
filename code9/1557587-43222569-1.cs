    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
               var intNum = 5;
               var strNum = "5";
               var result = intNum + strNum;
               // Let's re-purpose result to store an int
               result = 6;
               // or this
               result = intNum;
               Console.WriteLine(result);
            }
        }
    }

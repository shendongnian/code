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
               int intNum = 5;
               string strNum = "5";
               string result = String.Concat(intNum, strNum);         
               Console.WriteLine(result);
            }
        }
    }

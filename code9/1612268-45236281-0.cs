    using System;
    using System.Globalization;
    using System.Collections.Generic;
    class MainClass
    {
        public static void Main(string[] args)
        {
            //All the following case sensitive comparisons puts d before D
            Console.WriteLine("D".CompareTo("d"));
            Console.WriteLine(String.Compare("D", "d", false));
            Console.WriteLine(String.Compare("D", "d", false, CultureInfo.InvariantCulture));
            //All the following case sensitive comparisons puts capital D before small letter d
            Console.WriteLine(String.Compare("D", "d", CultureInfo.InvariantCulture, CompareOptions.Ordinal));
            //The following is case insensitive
            Console.WriteLine(String.Compare("D", "d", true));
            //The default string ordering in my case is d before D
            var list = new List<string>(new[] { "D", "d" });
            list.Sort();
            foreach (var s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
    //Results on repl.it
    //Mono C# compiler version 4.0.4.0
    //   
    //1
    //1
    //1
    //-32
    //0
    //d
    //D
   

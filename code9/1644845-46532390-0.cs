    using System;
    using System.Text.RegularExpressions;
    namespace TestRegex
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                string begin = "-----BEGIN some variable text-----";
                string end = "-----END";
                Console.WriteLine(Regex.Replace(begin, "-----BEGIN .*-----", ""));
	     		Console.WriteLine(Regex.Replace(end, "-----END.*", ""));
                Console.ReadLine();
		    }
        }
    }

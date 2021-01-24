    using System;
    using System.Text.RegularExpressions;
    using System.Text;
    
    namespace RegExTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                var input = "Test_AA_234_6874_Test";
                var matchText = "Test";
                var replacement = String.Empty;
    
                var regex = new Regex("^" + matchText);
    
                var output = regex.Replace(input, replacement);
    
                Console.WriteLine("Converted String: {0}", output);
    
                Console.ReadKey();
    
            }
        }
    }

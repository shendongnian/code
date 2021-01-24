    using System;
    using System.Net;
    namespace StackOverflow_EncodingSpecialCharacters
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string input = @"trmp % al1 €haced£rs Àc17ç";
                Console.WriteLine($"Input:  \t{input}");
                string encoded = WebUtility.HtmlEncode(input);
                Console.WriteLine($"Encoded: \t{encoded}");
                string output = WebUtility.HtmlDecode(encoded);
                Console.WriteLine($"Output: \t{output}");
                Console.ReadKey();
            }
        }
    }

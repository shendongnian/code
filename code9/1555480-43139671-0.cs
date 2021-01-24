    using System;
    using System.Text;
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main()
            {
                long n = 12349874529768521;
                string baseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz@#";
                var encoded = AsBaseN(n, baseChars.ToCharArray());
                Console.WriteLine(encoded); // Prints "9HXNyK2uh"
                long decoded = AsLong(encoded, baseChars.ToCharArray());
                Console.WriteLine(decoded); // Prints "12349874529768521"
            }
            public static string AsBaseN(long value, char[] baseChars)
            {
                var result = new StringBuilder();
                int targetBase = baseChars.Length;
                do
                {
                    result.Append(baseChars[value % targetBase]);
                    value /= targetBase;
                }
                while (value > 0);
                return result.ToString();
            }
            public static long AsLong(string number, char[] baseChars)
            {
                long result = 0;
                int numberBase = baseChars.Length;
                long multiplier = 1;
                foreach (char c in number)
                {
                    result += multiplier * Array.IndexOf(baseChars, c);
                    multiplier *= numberBase;
                }
                return result;
            }
        }
    }

    using System;
    using System.Collections.Generic;
    namespace SplitString
    {
        class Program
        {
            public static List<string> GetStrings(string input, char delimiter, string prefix)
            {
                // Pre-load buffer with prefix
                string buffer = prefix;
                List<string> result = new List<string>();
                foreach (var c in input)
                {
                    if (c == delimiter)
                    {
                        // We have hit a delimeter so we have a result
                        result.Add(buffer);
                        buffer += prefix;
                    }
                    else
                    {
                        buffer += c;
                    }
                }
                // At end of string need to add last result
                result.Add(buffer);
                return result;
            }
            static void Main(string[] args)
            {
                var strings = GetStrings(@"C:\Program Files(x86)\Mozilla Firefox\dictionaries ", '\\', "/");
                foreach (var s in strings)
                {
                    Console.Out.WriteLine(s);
                }
            }
        }
    }

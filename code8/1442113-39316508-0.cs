    using System;
    using System.Text.RegularExpressions;
    
    namespace RegularExpresion
    {
        class Program
        {
            private static Regex regex = null;
    
            static void Main(string[] args)
            {
                string input_text = @"Some Înput text here,
    Îs another lÎne of thÎs text.";
    
                string line_pattern = "\n";
    
                string invalid_character = "Î";
    
                regex = new Regex(line_pattern);
    
                /// Check is multiple or single line document
                if (IsMultipleLine(input_text))
                {
                    Console.WriteLine("Is a multiple line file");
    
                    MatchCollection matches = Regex.Matches(input_text, "^(.+)$", RegexOptions.Multiline);
    
                    int line = 0;
    
                    foreach (Match match in matches)
                    {
                        foreach (Capture capture in match.Captures)
                        {
                            line++;
    
                            Console.WriteLine($"Line: {line}");
    
                            RegexpLine(capture.Value, invalid_character);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Is a single line file");
    
                    RegexpLine(input_text, invalid_character);
                }
    
                Pause();
            }
    
            public static bool IsMultipleLine(string input) => regex.IsMatch(input);
    
            public static void RegexpLine(string line, string characters)
            {
                regex = new Regex(characters);
    
                MatchCollection mc = regex.Matches(line);
    
                Console.WriteLine($"How many matches: {mc.Count}");
    
                foreach (Match match in mc)
                    Console.WriteLine($"Index: {match.Index}");
            }
    
            public static ConsoleKeyInfo Pause(string message = "please press ANY key to continue...")
            {
                Console.WriteLine(message);
    
                return Console.ReadKey();
            }
        }
    }

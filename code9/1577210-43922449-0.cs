    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(ConsoleColor.Red,"Hello {0},{2} {1}","Name1", "Name2", "Name3");
    
            }
        }
    
        public static class Console
        {
            private static Regex _writeRegex = new Regex("<[fb]=\\w+>");
            public static void WriteLine(ConsoleColor c,string value,params object[] prms)
            {
                for(int i=0;i<prms.Length;i++)
                {
                    prms[i] = "<f=" + c.ToString().ToLower() + ">" + prms[i];
                }
                Write(String.Format(value,prms)+Environment.NewLine);
            }
    
            public static void Write(string value)
            {
                ConsoleColor defaultForegroundColor = System.Console.ForegroundColor;
                ConsoleColor defaultBackgroundColor = System.Console.BackgroundColor;
    
                var segments = _writeRegex.Split(value);
                var colors = _writeRegex.Matches(value);
                for (int i = 0; i < segments.Length; i++)
                {
                    if (i > 0)
                    {
                        ConsoleColor consoleColor;
                        // Now that we have the color tag, split it int two parts, 
                        // the target(foreground/background) and the color.
                        var splits = colors[i - 1].Value
                            .Trim(new char[] { '<', '>' })
                            .Split('=')
                            .Select(str => str.ToLower().Trim())
                            .ToArray();
                        // if the color is set to d (default), then depending on our target,
                        // set the color to be the default for that target.
                        if (splits[1] == "d")
                            if (splits[0][0] == 'b')
                                consoleColor = defaultBackgroundColor;
                            else
                                consoleColor = defaultForegroundColor;
                        else
                            // Grab the console color that matches the name passed. 
                            // If none match, then return default (black).
                            consoleColor = Enum.GetValues(typeof(ConsoleColor))
                                .Cast<ConsoleColor>()
                                .FirstOrDefault(en => en.ToString().ToLower() == splits[1]);
                        // Set the now chosen color to the specified target.
                        if (splits[0][0] == 'b')
                            System.Console.BackgroundColor = consoleColor;
                        else
                            System.Console.ForegroundColor = consoleColor;
                    }
    
                    // Only bother writing out, if we have something to write.
                    if (segments[i].Length > 0)
                        System.Console.Write(segments[i]);
                }
                System.Console.ForegroundColor = defaultForegroundColor;
                System.Console.BackgroundColor = defaultBackgroundColor;
            }
        }
    }

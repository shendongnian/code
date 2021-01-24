            public void ColorToConsole(ConsoleColor c, string s, string p)
            {
               //GET THE SUBSTRING TILL {0} AND WRITE IT TO CONSOLE
                string substr = s.Substring(0,s.IndexOf("{0}"));
                Console.Write(substr);
    
                //NOW SET THE FORE GROUND COLOR. WRITE THE REST
                Console.ForegroundColor = c;
                Console.Write(p);
            }

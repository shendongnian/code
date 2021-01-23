    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
          
            static void Main(string[] args)
            {
                string[] input = { "STAR",
                                    "SUN",
                                    "SUN",
                                    "SUN",
                                    "SUN",
                                    "SUN",
                                    "MOON",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "STAR",
                                    "MOON"
                                 };
                Dictionary<string, int> dict = new Dictionary<string, int>();
                List<string> output = new List<string>();
                foreach (string str in input)
                {
                    if (dict.ContainsKey(str))
                    {
                        int count = dict[str];
                        if ((count % 5) == 0)
                        {
                            output.Add(str);
                        }
                        dict[str] += 1; 
                    }
                    else
                    {
                        dict.Add(str, 0);
                    }
                }
          
            }
        }
    }

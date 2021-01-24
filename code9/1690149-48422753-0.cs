    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace Oppgave3Lesson1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                string input = "";
                List<string> lines = new List<string>();
                StreamReader reader = new StreamReader(FILENAME);
                Boolean foundStart = false;
                while ((input = reader.ReadLine()) != null)
                {
                    if (!foundStart)
                    {
                        if(input.StartsWith("Start")) foundStart = true;
                    }
                    else
                    {
                        if (input.StartsWith("End")) break;
                        lines.Add(input);
                    }
                }
     
            }
        }
    }

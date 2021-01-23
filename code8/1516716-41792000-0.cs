    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.txt";
            const string OUTPUT_FILENAME = @"c:\temp\test1.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(INPUT_FILENAME);
                StreamWriter writer = new StreamWriter(OUTPUT_FILENAME);
                string inputLine = "";
                int lineCount = 0;
                while ((inputLine = reader.ReadLine()) != null)
                {
                    if (++lineCount == 1)
                    {
                        writer.WriteLine(inputLine);
                    }
                    else
                    {
                        string[] inputArray = inputLine.Split(new char[] {'|'});
                        writer.WriteLine(string.Join("|", inputArray.Take(43)));
                    }
                }
                reader.Close();
                writer.Flush();
                writer.Close();
            }
        }
    }

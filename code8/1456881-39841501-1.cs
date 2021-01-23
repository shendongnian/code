    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Net;
    namespace ConsoleApplication17
    {
        class Program
        {
            const string inputFilename = @"c:\temp\test.xml";
            const string outputFilename = @"c:\temp\test.txt";
            const int COPY_LINES = 10000;
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(inputFilename, Encoding.UTF8);
                StreamWriter writer = new StreamWriter(outputFilename, false,  Encoding.UTF8);
                Boolean start = false;
                int i = 0;
                while (i < COPY_LINES)
                {
                    string inputLine = reader.ReadLine();
                    if(inputLine.Contains("xn:SubNetwork id=\"G-Mum\""))
                    {
                        start = true;
                    }
                    if (start)
                    {
                        writer.WriteLine(inputLine);
                        i++;
                    }
                }
                writer.Flush();
                writer.Close();
                MemoryStream stream = new MemoryStream(1000000);
            }
        }
    }

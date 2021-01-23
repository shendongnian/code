    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
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
                for (int i = 0; i < COPY_LINES; i++)
                {
                    string inputLine = reader.ReadLine();
                    writer.WriteLine(inputLine);
                }
                writer.Flush();
                writer.Close();
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication43
    {
        class Program
        {
            const string IN_FILENAME = @"c:\temp\in.txt";
            const string OUT_FILENAME = @"c:\temp\out.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(IN_FILENAME);
                StreamWriter writer = new StreamWriter(OUT_FILENAME);
                string inputline = "";
                while ((inputline = reader.ReadLine()) != null)
                {
                    writer.WriteLine("237" + inputline + "#");
                }
                writer.Flush();
                writer.Close();
                reader.Close();
     
            }
        }
    }

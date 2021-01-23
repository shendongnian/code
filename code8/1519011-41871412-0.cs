    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication43
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = "";
                string inputline = "";
                StreamReader reader = new StreamReader(FILENAME);
                while ((inputline = reader.ReadLine()) != null)
                {
                    if (inputline.Trim().StartsWith("<"))
                    {
                        xml += inputline + "\n";
                    }
                }
                
            }
        }
     
    }

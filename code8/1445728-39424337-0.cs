    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.csv";
            static void Main(string[] args)
            {
                StreamWriter writer = new StreamWriter(FILENAME);
                string input = "<coordinates>80.41501791166907,15.31966921785412,80.66681262872422,15.30770770315245,81.04469571795477,15.27884283211159,0 </coordinates>";
                XDocument doc = XDocument.Parse(input);
                string[] groups = ((string)doc.Element("coordinates")).Trim().Split(new string[] {",0"}, StringSplitOptions.RemoveEmptyEntries);
                Boolean first = true;
                foreach (string group in groups)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        writer.WriteLine();
                    }
                    string[] coordinates = group.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    writer.WriteLine("{0} {1}", coordinates.Length / 2, 0);
                    writer.WriteLine();
                    for (int i = 0; i < coordinates.Count() - 1; i += 2)
                    {
                        writer.WriteLine("{0},{1}", coordinates[i], coordinates[i + 1]);
                    }
                }
                writer.Flush();
                writer.Close();
            }
        }
    }

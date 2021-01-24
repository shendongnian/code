    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                XDocument doc = new XDocument();
                doc.Add(new XElement("ExampleDataSet"));
                XElement root = doc.Root;
                StreamReader reader = new StreamReader(FILENAME);
                int rowCount = 1;
                string line = "";
                string[] headers = null;
                while((line = reader.ReadLine()) != null)
                {
                    if (rowCount++ == 1)
                    {
                        headers = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    else
                    {
                        string[] arrayStr = line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        XElement newRow = new XElement("Example");
                        root.Add(newRow);
                        for (int i = 0; i < arrayStr.Count(); i++)
                        {
                            newRow.Add(new XAttribute(headers[i], arrayStr[i]));
                        }
                    }
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<KeyValuePair<string, List<KeyValuePair<double, double>>>> instructions = new List<KeyValuePair<string, List<KeyValuePair<double, double>>>>();
                foreach (XElement instruction in doc.Descendants("path").FirstOrDefault().Elements())
                {
                    List<KeyValuePair<double, double>> points = new List<KeyValuePair<double, double>>();
                    for (int i = 0; i < instruction.Attributes().Count(); i += 2)
                    {
                        points.Add(new KeyValuePair<double,double>((double)instruction.Attributes().Skip(i).FirstOrDefault(), (double)instruction.Attributes().Skip(i + 1).FirstOrDefault()));
                    }
                    instructions.Add(new KeyValuePair<string, List<KeyValuePair<double,double>>>( instruction.Name.LocalName, points));
                }
     
            }
        }
    }

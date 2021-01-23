    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication16
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> Strings = new List<string>() {
                        "first string value Here",
                        "Second string value here"
                };
                List<XElement> output = Strings.Select((x, i) => new XElement("Line" + (i + 1).ToString(), x)).ToList(); 
            }
        }
    }

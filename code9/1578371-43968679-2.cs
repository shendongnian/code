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
            static void Main(string[] args)
            {
                string input =
                    "<Message>" +
                      "<Param1 value = \"val1\"/>" +
                      "<Param2 value = \"val2\"/>" +
                    "</Message>" +
                    "<Message>" +
                      "<Param1 value = \"val1\"/>" +
                      "<Param2 value = \"val2\"/>" +
                    "</Message>";
               
                XElement message = 
                    new XElement("Root", input);
                var results = message.Elements("Message")
                    .Where(x => x.HasElements)
                    .Select(x => x.Elements()
                        .GroupBy(y => y.Name.LocalName, z => z)
                        .ToDictionary(y => y.Key, z => (string)z.FirstOrDefault()
                            .Attribute("value")))
                    .ToList();
            }
        }
    }

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
                string xml =
                    "<NewDataSet>" +
                        "<EYE>" +
                           "<DAD>Blue</DAD>" +
                           "<MOM>Brown</MOM>" +
                        "</EYE>" +
                        "<HAIR>" +
                           "<DAD>Black</DAD>" +
                           "<MOM>Brown</MOM>" +
                        "</HAIR>" +
                        "<SKIN>" +
                           "<DAD>White</DAD>" +
                           "<MOM>White</MOM>" +
                        "</SKIN>" +
                    "</NewDataSet>";
                XElement dataset = XElement.Parse(xml);
                Dictionary<string, string> dadDict = dataset.Elements()
                    .GroupBy(x => x.Name.LocalName, y => (string)y.Element("DAD"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }

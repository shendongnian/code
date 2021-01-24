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
                   "<Root>" +
                        "<State value=\"AState\">" +
                           "<County value=\"ACounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                           "<County value=\"BCounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                           "<County value=\"CCounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                         "</State>" +
                        "<State value=\"BState\">" +
                           "<County value=\"ACounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                           "<County value=\"BCounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                           "<County value=\"CCounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                         "</State>" +
                         "<State value=\"CState\">" +
                           "<County value=\"ACounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                           "<County value=\"BCounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                           "<County value=\"CCounty\">" +
                               "<City value=\"ACity\"/>" +
                               "<City value=\"BCity\"/>" +
                               "<City value=\"CCity\"/>" +
                            "</County>" +
                         "</State>" +
                        "</Root>";
               XElement root = XElement.Parse(xml);
               List<Foo> foos = Helper(root); 
            }
            public static List<Foo> Helper(XElement element)
            {
                if (element.HasElements)
                {
                    string tagName = ((XElement)element.FirstNode).Name.LocalName;
                    List<Foo> children = element.Elements(tagName).Select(x => new Foo()
                    {
                        Name = tagName,
                        Value = (string)x.Attribute("value"),
                        foos = Helper(x)
                    }).ToList();
                    return children;
                }
                else
                {
                    return null;
                }
            }
        }
        public class Foo
        {
            public string Name { get; set; }
            public string Value { get; set; }
            
            public List<Foo> foos { get; set; }
        }
    }

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
            static void Main(string[] args)
            {
                string xml = 
                    "<person>" +
                        "<name>a</name>" +
                    "</person>" +
                    "<person>" +
                        "<name>b</name>" +
                    "</person>";
                xml = "<Root>" + xml + "</Root>";
                XDocument doc = XDocument.Parse(xml);
               
                List<Person> people = doc.Descendants("person").Select(x => new Person() {
                    Name = (string)x.Element("name")
                }).ToList();
            }
        }
        public class Person
        {
            public string Name { get; set; }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                  "<Root>" +
                  "<person>" +
                    "<name>Miller</name>" +
                    "<car>BMW</car>" +
                  "</person>" +
                  "<person>" +
                    "<name>Smith</name>" +
                    "<address>New York</address>" +
                    "<pets>" +
                      "<pet>Cat</pet>" +
                      "<pet>Dog</pet>" +
                    "</pets>" +
                  "</person>" +
                  "</Root>";
                XDocument doc = XDocument.Parse(xml);
                Person.people = doc.Descendants("person").Select(x => new Person() {
                    name = (string)x.Element("name"),
                    car = (string)x.Element("car"),
                    address = (string)x.Element("address"),
                    pets = x.Descendants("pet").Select(y => (string)y).ToList()
                }).ToList();
            }
     
        }
        public class Person
        {
            public static List<Person> people { get; set; }
            public string name { get; set; }
            public string car { get; set; }
            public string address { get; set; }
            public List<string> pets { get; set; }
        }
    }

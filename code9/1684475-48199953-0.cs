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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                Person person = new Person(xml);
            }
        }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Address { get; set; }
            public Person(string xml)
            {
                XDocument doc = XDocument.Parse(xml);
                foreach(XElement xReturn in doc.Descendants("return"))
                {
                    string name = (string)xReturn.Element("name");
                    string value = (string)xReturn.Element("value");
                    switch (name)
                    {
                        case "firstName" :
                            FirstName = value;
                            break;
                        case "lastName":
                            LastName = value;
                            break;
                        
                        case "dateOfBirth":
                            DateOfBirth = DateTime.Parse(value);
                            break;
                        
                        case "address":
                            Address = value;
                            break;
                    }
                }
            }
        }
    }

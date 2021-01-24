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
                XNamespace ns = doc.Root.GetDefaultNamespace();
                List<Student> students = doc.Descendants(ns + "Item").Select(x => new Student() {
                    week = (DateTime)x.Element(ns + "Week"),
                    name = (string)x.Element(ns + "Name"),
                    counsel = (int)x.Element(ns + "Counsel"),
                    completed = (int)x.Element(ns + "Completed") == 1 ? true : false,
                    description = (string)x.Element(ns + "Description")
                }).ToList();
                var weeks = students.GroupBy(x => x.week).ToList();
            }
        }
        public class Student
        {
            public DateTime week { get; set;}
            public string name { get; set; }
            public int counsel { get; set; }
            public Boolean completed { get; set; }
            public string description { get; set; }
        }
    }

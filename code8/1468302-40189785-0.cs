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
                var schedules = doc.Descendants("Schedule").Select(x => new {
                    courses = x.Elements("Course").Select(y => new {
                        id = (string)y.Element("ID"),
                        section = (string)y.Element("Section"),
                        name = (string)y.Element("Name"),
                        days = (string)y.Element("Days"),
                        stime = ((DateTime)y.Element("STime")).TimeOfDay,
                        etime = ((DateTime)y.Element("ETime")).TimeOfDay,
                        location = (string)y.Element("Location"),
                        teacher = (string)y.Element("Teacher")
                    }).ToList()
                }).ToList();
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication49
    {   
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Employee.employees = doc.Descendants("Testdata").Select(x => new Employee()
                {
                    FirstName = x.Elements().Where(y => (string)y.Attribute("name") == "fname").Select(y => (string)y).FirstOrDefault(),
                    LastName = x.Elements().Where(y => (string)y.Attribute("name") == "lname").Select(y => (string)y).FirstOrDefault()
                }).ToList();
            }
        }
        public class Employee
        {
            public static List<Employee> employees = new List<Employee>();
            public string LastName {get; set;}
            public string FirstName {get;set;}
        }
     
       
    }

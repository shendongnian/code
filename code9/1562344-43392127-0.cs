    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
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
                List<XElement> collections = doc.Descendants("Collection").ToList();
                foreach (XElement collection in collections)
                {
                    List<XElement> abcs = collection.Elements("abc").ToList();
                    if (((string)abcs[0].Attribute("Name")).StartsWith("Employee"))
                    {
                        Employee newEmployee = new Employee();
                        Employee.employees.Add(newEmployee);
                        newEmployee.Id = abcs.Where(x => (string)x.Attribute("Name") == "EmployeeId").Select(x => (x.IsEmpty) ? null : (int?)x).FirstOrDefault();
                        newEmployee.Name  = (string)abcs.Where(x => (string)x.Attribute("Name") == "EmployeeName").FirstOrDefault();
                    }
                    if (((string)abcs[0].Attribute("Name")).StartsWith("Institute"))
                    {
                        Institution newInstitution = new Institution();
                        Institution.institutions.Add(newInstitution);
                        newInstitution.Id = (int?)abcs.Where(x => (string)x.Attribute("Name") == "InstituteId").Select(x => (x.IsEmpty) ? null : (int?)x).FirstOrDefault();
                        newInstitution.Name = (string)abcs.Where(x => (string)x.Attribute("Name") == "InstituteName").FirstOrDefault();
                        newInstitution.Location = (string)abcs.Where(x => (string)x.Attribute("Name") == "InstituteLocation").FirstOrDefault();
                    }
                }
            }
        }
        public class Employee
        {
            public static List<Employee> employees = new List<Employee>();
            public int? Id { get; set; }
            public string Name { get; set; }
        }
        public class Institution
        {
            public static List<Institution> institutions = new List<Institution>();
            public int? Id { get; set;}
            public string Name {get; set; }
            public string Location {get; set;}
        }
    }

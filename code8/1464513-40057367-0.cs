    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Company company = new Company();
                XmlSerializer serializer = new XmlSerializer(typeof(Company));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, company);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                IEnumerable<string> Names = from Emps in XDocument.Load(FILENAME)
                                                               .Descendants("Employee")
                                            where (int)Emps.Element("Salary") > 10000
                                            select Emps.Element("Name").Value;
                foreach (string name in Names)
                {
                    Console.WriteLine(name);
                }
                Console.ReadLine();
            }
        }
        public class Company
        {
            [XmlElement("Employee")]
            public Employee[] employees = Employee.GetAllEmployee();
        }
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Salary { get; set; }
            public static Employee[] GetAllEmployee()
            {
                Employee[] Emp = new Employee[5];
                Emp[0] = new Employee { Id = 101, Name = "Mery", Gender = "Female", Salary = 10000 };
                Emp[1] = new Employee { Id = 102, Name = "Lucy", Gender = "Female", Salary = 12000 };
                Emp[2] = new Employee { Id = 103, Name = "Jeny", Gender = "Female", Salary = 15000 };
                Emp[3] = new Employee { Id = 104, Name = "Lilly", Gender = "Female", Salary = 10000 };
                Emp[4] = new Employee { Id = 105, Name = "Sony", Gender = "Female", Salary = 17000 };
                return Emp;
            }
        }
    }

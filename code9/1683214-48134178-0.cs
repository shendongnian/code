    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Collections.Generic;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var empList = new List<Employee>();
                for (int i=0; i<10; i++) {
                    empList.Add(GenerateTestEmployee(i));
                }
                var xmlConverter = new XmlConverter();
                var employeesNode = new XElement(
                    "Employees",
                    empList.Select(emp => xmlConverter.Convert(emp))
                );
                Console.WriteLine(employeesNode.ToString());
            }
            private static Employee GenerateTestEmployee(int seed) {
                return new Employee() {
                    ID = Guid.NewGuid(),
                    FName = seed.ToString(),
                    LName = "Example",
                    DOB = DateTime.UtcNow.AddYears(-20).AddYears(-seed),
                    Sex = seed % 2 == 0 ? "Male" : "Female",
                    WorkHistory = GenerateTestWorkHistory(seed)
                };
            }
            private static WorkHistory GenerateTestWorkHistory(int seed) {
                if (seed % 7 == 0) {
                    return null;
                }
                return new WorkHistory() {
                    Complaints = Enumerable.Repeat("Complaint!", seed % 2).ToList(),
                    Commendations = Enumerable.Repeat("Commendation!", seed % 3).ToList()
                };
            }
        }
        public class Employee {
            public Guid ID { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public DateTime DOB { get; set; }
            public string Sex { get; set; }
            public WorkHistory WorkHistory { get; set; }
        }
        public class WorkHistory {
            public List<string> Complaints { get; set; }
            public List<string> Commendations { get; set; }
        }
        public class XmlConverter {
            public XElement Convert(Employee emp) {
                var attributes = new List<XAttribute> { 
                    new XAttribute("ID", emp.ID)
                };
                var elements = new List<XElement> {
                    new XElement("FName", emp.FName),
                    new XElement("LName", emp.LName),
                    new XElement("DOB", emp.DOB),
                    new XElement("Sex", emp.Sex)
                };
                var workHistory = Convert(emp.WorkHistory);
                if (workHistory != null) {
                    elements.Add(workHistory);
                }
                return new XElement("Employee", attributes, elements);
            }
            private XElement Convert(WorkHistory hist) {
                if (hist == null) {
                    return null;
                }
                var elements = new List<XElement>();
                if (hist.Complaints != null && hist.Complaints.Any()) {
                    var complaints = new XElement(
                       "Complaints",
                       hist.Complaints.Select(comp => new XElement("Complaint", comp))
                   );
                   elements.Add(complaints);
                }
                if (hist.Commendations != null && hist.Commendations.Any()) {
                    var commendations = new XElement(
                       "Commendations",
                       hist.Commendations.Select(comm => new XElement("Commendation",comm))
                   );
                   elements.Add(commendations);
                }
                return elements.Any() ? new XElement("WorkHistory", elements)
                                      : null;
            }
        }
    }

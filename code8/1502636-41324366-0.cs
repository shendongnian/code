    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var results = Department.departments.Select(x => new {
                    deptmentName = x.Name,
                    maxEmployeeReports = x.Employees.Select(y => new { name = y.Name, count = y.Reports.Count, employee = y }).OrderByDescending(z => z.count).FirstOrDefault()
                }).ToList();
            }
        }
        public class Employee
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public long DepartmentId { get; set; }
            public Department Department { get; set; }
            public ICollection<Report> Reports { get; set; }
        }
        public class Department
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public ICollection<Employee> Employees { get; set; }
            public static List<Department> departments = new List<Department>();
        }
        public class Report
        {
        }
    }

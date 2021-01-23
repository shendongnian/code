    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
    
            empList.Add(new Employee()
            {
                ID = 101,
                Name = "Test1",
                Salary = 5000,
                Experience = 5
            });
    
            empList.Add(new Employee()
            {
                ID = 101,
                Name = "Test2",
                Salary = 2000,
                Experience = 1
            });
    
            empList.Add(new Employee()
            {
                ID = 101,
                Name = "Test3",
                Salary = 4000,
                Experience = 4
            });
    
            IsPromotable isPromotable = new IsPromotable(Promote);
    
            Employee.PromoteEmployee(empList, isPromotable);
        }
    
        public static bool Promote(Employee emp)
        {
            if (emp.Experience >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public delegate bool IsPromotable(Employee empl);
    
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Salary { get; set; }
            public int Experience { get; set; }
    
            public static void PromoteEmployee(List<Employee> employeeList, IsPromotable IsEligibleToPromote)
            {
                foreach (Employee employee in employeeList)
                {
    
                    if (IsEligibleToPromote(employee))
                    {
                        Console.WriteLine(employee.Name + " promoted");
                    }
                }
            }
        }
    }

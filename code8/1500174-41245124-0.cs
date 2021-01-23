    class Employee
    {
        public int Id;
        public string Name;
       
        public void EmployeeXMLs()
        {
            var Employees = new[] { new Employee
                                        {Name="Rajat Jaiswal",
                               Id = 101
                               },
                       new Employee      {Name="Sharad Jaiswal",
                               Id = 102
                               },
                      };
            XElement contacts = new XElement("employees",
                        from p in Employees
                        select new XElement("employee",
                            new XElement("Id", p.Id),
                            new XElement("Name",p.Name)
                            
                        )
                    );
            Console.WriteLine(contacts);
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (MyDbContext dbContext = new MyDbContext())
                {
                    dbContext.Departments.Add(new Department()
                    {
                        Name = "Some Department1",
                        Employees=new List<Employee>()
                        {
                            new Employee() { Name = "John Doe" }
                        }
                    });
    
                    dbContext.SaveChanges();
    
                    var department = dbContext.Departments.FirstOrDefault(d => d.Name == "Some Department1");
    
                    if (department.Employees != null)
                    {
                        foreach (var item in department.Employees)
                        {
                            Console.WriteLine(item.Name);
                        }
                    }
                }
            }
        }
    
        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Employee> Employees { get; set; }
        }
    
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public class MyDbContext : DbContext
        {
            public DbSet<Department> Departments { get; set; }
            public DbSet<Employee> Employees { get; set; }
        }
    }

    using Autofac;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace AutofacExample
    {
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    
        public interface IEmployeeRepository
        {
            Employee FindById(int id);
        }
    
        public interface IEmployeeService
        {
            void Print(int employeeId);
        }
    
        public class EmployeeRepository : IEmployeeRepository
        {
            private readonly List<Employee> _data = new List<Employee>()
            {
                new Employee { Id = 1, Name = "Employee 1"},
                new Employee { Id = 2, Name = "Employee 2"},
            };
            public Employee FindById(int id)
            {
                return _data.SingleOrDefault(e => e.Id == id);
            }
        }
    
        public class EmployeeService : IEmployeeService
        {
            private readonly IEmployeeRepository _repository;
            public EmployeeService(IEmployeeRepository repository)
            {
                _repository = repository;
            }
            public void Print(int employeeId)
            {
                var employee = _repository.FindById(employeeId);
                if (employee != null)
                {
                    Console.WriteLine($"Id:{employee.Id}, Name:{employee.Name}");
                }
                else
                {
                    Console.WriteLine($"Employee with Id:{employeeId} not found.");
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var container = BuildContainer();
                var employeeSerive = container.Resolve<IEmployeeService>();
                employeeSerive.Print(1);
                employeeSerive.Print(2);
                employeeSerive.Print(3);
                Console.ReadLine();
            }
    
            static IContainer BuildContainer()
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<EmployeeRepository>()
                       .As<IEmployeeRepository>()
                       .InstancePerDependency();
                builder.RegisterType<EmployeeService>()
                       .As<IEmployeeService>()
                       .InstancePerDependency();
                return builder.Build();
            }
        }
    }

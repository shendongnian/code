    public class Employee
    {
        public double Salary {get; set;}
    }
 
    public class FirstViewModel
    {
        public FirstViewModel()
        {
              Employees = new List<Employee>
              {
                  new Employee() { Salary=10000 }
                  new Employee() { Salary=15000 }
              }
        }
        public List<Employee> Employees {get;}
    }

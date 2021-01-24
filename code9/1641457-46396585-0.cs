    public class Employee
    {
        public string Name { get; set; }
        public double Pay { get; set; }
    }
    
    public class EmployeeController
    {
         private static EmployeeController employeeController = new EmployeeController();
         private { Employees = new List<Employee>(); }
         public static EmployeeController Instance => employeeController;
    
         public List<Employee> Employees { get; set; }
    
         public double TotalPay
         {
             get
             {
                   var totalPay = 0d;
                   foreach (var employee in Employees)
                        totalPay += employee.Pay;
                   return totalPay;
             }
         }
    }

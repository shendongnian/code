    public class Employee {
          static int NextEmployeeId;  // a counter across all employees
          public int EmployeeId;  // this instance's employee id
          public string Name;     // this instance's name.
          static Employee() {
              Employee.NextEmployeeId = 1;  // first employee gets 1.
          }
          public Employee(string Name) {
               this.Name = Name;
               this.EmployeeId = Employee.NextEmployeeId++;  // take an id and increment for the next employee
          }
    }

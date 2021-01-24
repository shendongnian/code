    class Employee
    {
         public int EmployeeId {get; set;}
         // every employee belongs to exactly one Department
         public int DepartmentId {get; set;}
         public virtual Department Department {get; set;}
         ... // other properties, not meaningful for this question
    }

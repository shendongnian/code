    public static class ManagerTeam
    {
         //You need to set this when the user signs in
         internal static Employee CurrentEmployee;
         //This method will return the full list of employees from your data source, you could use an IQueryable instead of the list so you can filter and make queries
         public static IList<Employee> GetEmployees()
         {
              return db.Employees;
         }
         public static IList<Employee> GetEmployeeByPosition(string position)
         {
              return db.Employees.Where(x => x.Position == position);
         }
         public static IList<Employee> GetEmployeesByShift(string shift)
         {
              return db.Employees.Where(x => x.Shift == shift);
         }
         public static IList<Employee> GetEmployeesByTeam(string team)
         {
              return db.Employees.Where(x => x.Team == team);
         }
         
         public static void CreateEmployee(Employee employee)
         {
               // Only managers can add employees
               if (CurrentEmployee.Position == "Manager") {
                   db.Employees.Add(employee);
               }     
         }
         ...
    }

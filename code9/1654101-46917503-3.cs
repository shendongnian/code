    public static class ManagerTeam
    {
         //This method will return the full list of employees from your data source, you could use an IQueryable instead of the list so you can filter and make queries
         public static IList<Employee> GetEmployees()
         {
              return db.Employees;
         }
         public static IList<Employee> GetEmployeeByPosition(string position)
         {
              return db.Employees.Where(x => x.Position == position);
         }
         
         public static void CreateEmployee(Employee employee)
         {
               db.Employees.Add(employee);
         }
         ...
    }

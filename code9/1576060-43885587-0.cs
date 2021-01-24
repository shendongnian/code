    public class EmployeeService {
    public List<Employee> GetEmployee() {
        return dbContext.Employee.Where(m => m.Name.Contains("A") || m.Name.Contains("B")).ToList();
       }
    }

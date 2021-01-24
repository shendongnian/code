    interface Repository<T> {
            List<T> GetAll();
    }
    public class EmployeeRepository : Repository<Employee> {       
            public List<Employee> GetAll() {
                List<Employee> employees = new List<Employee>();
                return employees;
            }
    }

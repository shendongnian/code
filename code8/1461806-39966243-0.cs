    public class EmployeeRepository : IRepository<Employee>
    {
        private List<string> employees = new List<string>();
        public void Create(string employeeId)
        {
            this.employees.Add(employeeId);
        }
    }

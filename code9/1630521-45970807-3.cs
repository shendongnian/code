    public class EmployeeCollection
    {
        public List<Employee> Employees;
        public EmployeeCollection()
        {
            Employees = new List<Employee>();
        }
        public void AddTypeOne(int id, string name)
        {
            if (Employees == null)
                Employees = new List<Employee>();
            Employees.Add(new EmpTypeOne(id, name));
        }
        public void AddTypeTwo(int id, string name, string city)
        {
            if (Employees == null)
                Employees = new List<Employee>();
            Employees.Add(new EmpTypeTwo(id, name, city));
        }
    }

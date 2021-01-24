    public EmployeeService : IEmployeeService {
        public Employee AddEmployee(Employee emp) {
            using (EmployeeEntities dbEntity = new EmployeeEntities()) {
                dbEntity.Configuration.LazyLoadingEnabled = false;
                dbEntity.Employees.Add(emp);
                dbEntity.SaveChanges();
                return emp;
            }
        }
        //...other service members
    }

    public class DA : IDisposable
    {
        private SqlConnection sqlConn;
        private IRepository<Employee> employeeRepo;
        private IReposiotry<Whatever> whateverRepo;
        public DA(string connectionString)
        {
            this.sqlConnection = GetSqlConnection(connectionString);
            this.employeeRepo = new EmployeeRepository(this.sqlConnection);
            this.whateverRepo = new WhateverRepository(this.sqlConnection);
        }
        public IRepository<Employee> Employee { get { return employeeRepo; } }
        public IRepository<Whatever> Whatever { get { return whateverRepo; } }
    }

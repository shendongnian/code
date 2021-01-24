    public interface IRepository<T>
    {
        T GetById(int id);
    }
    public class EmployeeRepository : IRepository<Employee>
    {
        private SqlConnection sqlConn;
        public EmployeeRepository(SqlConnection sqlconn)
        {
            this.sqlConn = sqlConn;
        }
        public Employee GetById(int id)
        {
            return new Employee();
        }
    }

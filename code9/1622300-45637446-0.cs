    public class MySQLCustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
        public MySQLCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<CustomerOrder> GetCustomerOrdersByDate(int customerId, DateTime startDate, DateTime endDate)
        {
            //open a MySQL connection and execute query to retrieve customer orders
        }
    }
    public class MongoCustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;
    
        public MongoCustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    
        public List<CustomerOrder> GetCustomerOrdersByDate(int customerId, DateTime startDate, DateTime endDate)
        {
            //connect to mongo, get customers by running query
        }
    }
    
    public interface ICustomerRepository
    {
        List<CustomerOrder> GetCustomerOrdersByDate(int customerId, DateTime startDate, DateTime endDate);
    }

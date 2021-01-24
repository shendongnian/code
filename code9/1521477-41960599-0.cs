    public class DBService {
        private readonly IDbConnectionFactory connectionFactory;
        public DBService(IDbConnectionFactory connectionFactory) {
            this.connectionFactory = connectionFactory;
        }
        
        public IDbConnectionFactory DBFactory { get { return connectionFactory; } }
        public List<Customer> GetAllCustomers() {
            try {
                using (var connection = DBFactory.OpenDbConnection()) {
                    var dbResult = connection.Select<Customer>();
                    //... code omitted for brevity
                }
            } catch (Exception e) {
                //... code omitted for brevity
            }
        }
    }

    public class Customer
    {
        public bool Active { get; set; }
    }
    class Program : IDisposable
    {
        private readonly DbConnection _connection;
        public Program()
        {
            _connection = DbOpen();
        }
        static void Main(string[] args)
        {
            SqlMapper.AddTypeMap(typeof(bool), DbType.Int32);
            using (var program = new Program())
            {
                program.Run();
            }
        }
        private void Run()
        {
            _connection.Execute($"INSERT INTO customers ( active ) VALUES (:Activate)", new { Activate = true });
            _connection.Execute($"INSERT INTO customers ( active ) VALUES (:Activate)", new { Activate = false });
            var customers = new List<Customer>()
            {
                new Customer() {Active = true},
                new Customer() {Active = false}
            };
            _connection.Execute($"INSERT INTO customers ( active ) VALUES (:{nameof(Customer.Active)})", customers);
            var results = _connection.Query<Customer>("SELECT * FROM customers");
            foreach (var customer results)
            {
                Console.WriteLine($"{nameof(Customer.Active)} is {customer.Active}");
            }
        }
        private static DbConnection DbOpen()
        {
            var connectionSetting = ConfigurationManager.ConnectionStrings["oracle"];
            var dbFactory = DbProviderFactories.GetFactory(connectionSetting.ProviderName);
            var conn = dbFactory.CreateConnection();
            conn.ConnectionString = connectionSetting.ConnectionString;
            conn.Open();
            return conn;
        }
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }

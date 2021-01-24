    class Program
    {
        static void Main(string[] args)
        {
            var bll = new BLL();
            var person = bll.GetPerson();
            var orders = person.Orders; // GetOrders in DAL will be excuted here
        }
    }
    // BLL project
    public class BLL
    {
        public Person GetPerson()
        {
            return new DAL().GetPerson(1);
        }
    }
    // Entity Project
    public class Person
    {
        public Person()
        {
        }
        public Person(Lazy<IEnumerable<Order>> orders)
        {
            _orders = orders;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        private Lazy<IEnumerable<Order>> _orders = null;
        public IEnumerable<Order> Orders
        {
            get { return _orders?.Value; }
            set { _orders = new Lazy<IEnumerable<Order>>(() => value); }
        }
    }
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    // DAL Project
    public class DAL
    {
        public Person GetPerson(int id)
        {
            var person = new Person(new Lazy<IEnumerable<Order>>(() => GetOrders(id))) // Init lazy
            {
                Id = id,
                Name = "Person"
            };
            return person;
        }
        public IEnumerable<Order> GetOrders(int personId)
        {
            return new List<Order> { new Order { Id = 2, Name = "Order" } };
        }
    }

    public static class Program
    {
        public class Customer
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
        public class CustomerComparer : IEqualityComparer<Customer>
        {
            public bool Equals(Customer x, Customer y)
            {
                Console.WriteLine("hit!");
                return x.Id == y.Id && x.Name.Contains(y.Name);
            }
            public int GetHashCode(Customer obj)
            {
                return obj.Id.GetHashCode() ^ obj.Name.GetHashCode();
            }
        }
        public static void Main()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Id = "1234", Name = "smith" },
                new Customer() { Id = "1234", Name = "mit" }
            };
            var hashset = new HashSet<Customer>(customers, new CustomerComparer());
            var found = hashset.Contains(new Customer { Id = "1234", Name = "mit" }); // "mit" instead of an equals "smith" in the comparer.
            Console.WriteLine(found); // = true
        }
    }

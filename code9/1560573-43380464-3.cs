    public class Program {
        static List<Func<Customer, bool>> _rules = new List<Func<Customer, bool>>();
        static void Main(string[] args) {
            foreach (var i in Enumerable.Range(0, 10000)) {
                // generate simple expression, but joined with OR conditions because 
                // in this case (on random data) it will have to check them all
                // c => c.Name == ".." || c.Email == Y || c.LastEmailed > Z || territories.Contains(c.TerritoryID)
                var customer = Expression.Parameter(typeof(Customer), "c");
                var name = Expression.Constant(RandomString(10));
                var email = Expression.Constant(RandomString(12));
                var lastEmailed = Expression.Constant(DateTime.Now.AddYears(-20));
                var salesTerritories = Expression.Constant(Enumerable.Range(0, 5).Select(c => random.Next()).ToArray());
                var exp = Expression.OrElse(Expression.OrElse(Expression.OrElse(
                Expression.Equal(Expression.PropertyOrField(customer, "Name"), name),
                Expression.Equal(Expression.PropertyOrField(customer, "Email"), email)),
                Expression.GreaterThan(Expression.PropertyOrField(customer, "LastEmailed"), lastEmailed)),
                Expression.Call(typeof(Enumerable), "Contains", new Type[] {typeof(int)}, salesTerritories, Expression.PropertyOrField(customer, "SalesTerritoryId")));
                // compile
                var l = Expression.Lambda<Func<Customer, bool>>(exp, customer).Compile();
                _rules.Add(l);
            }
            var customers = new List<Customer>();
            // generate 1M customers
            foreach (var i in Enumerable.Range(0, 1_000_000)) {
                var cust = new Customer();
                cust.Name = RandomString(10);
                cust.Email = RandomString(10);
                cust.Phone = RandomString(10);
                cust.Birthday = DateTime.Now.AddYears(random.Next(-70, -10));
                cust.LastEmailed = DateTime.Now.AddDays(random.Next(-70, -10));
                cust.LastCalled = DateTime.Now.AddYears(random.Next(-70, -10));
                cust.SalesTerritoryId = random.Next();
                customers.Add(cust);
            }
            Console.WriteLine($"Started. Customers {customers.Count}, rules: {_rules.Count}");
            int matches = 0;
            var w = Stopwatch.StartNew();
            // just loop
            Parallel.ForEach(customers, c => {
                foreach (var rule in _rules) {
                    if (rule(c))
                        Interlocked.Increment(ref matches);
                }
            });
            w.Stop();
            Console.WriteLine($"matches {matches}, elapsed {w.ElapsedMilliseconds}ms");
            Console.ReadKey();
        }
        private static readonly Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
    public class Customer {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime LastEmailed { get; set; }
        public DateTime LastCalled { get; set; }
        public int AgeInYears
        {
            get { return DateTime.UtcNow.Year - Birthday.Year; }
        }
        public int SalesTerritoryId { get; set; }
    }

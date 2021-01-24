    public class Search
    {
        private static IDictionary<Options, Func<AppDbContext, string, IEnumerable<Customer>>> _searchMethods { get; }
        public AppDbContext Context { get; }
        static Search()
        {
            _searchMethods = new Dictionary<Options, Func<AppDbContext, string, IEnumerable<Customer>>>()
            {
                [Options.ByCountry] = GetByCountry,
                [Options.ByCompanyName] = GetByCompanyName,
            };
        }
        public Search(AppDbContext context)
        {
            Context = context;
        }
        public IEnumerable<Customer> Get(Options query, string argument)
            => _searchMethods[query](Context, argument);
        public static IEnumerable<Customer> GetByCountry (AppDbContext context, string countryName)
        {
            return context.Customers
               .Where(c => c.Country.ToLower().Contains(countryName.ToLower()))
               .ToList();
        }
        public static IEnumerable<Customer> GetByCompanyName (AppDbContext context, string companyName)
        {
            return context.Customers
                .Where(c => c.CompanyName.ToLower().Contains(companyName.ToLower()))
                .ToList()
        }
    }

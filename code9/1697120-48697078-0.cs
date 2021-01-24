    public class Search
    {
        public AppDbContext Context { get; }
        public IDictionary<Options, Func<string, IEnumerable<Customer>>> SearchMethods { get; }
        public Search(AppDbContext context)
        {
            Context = context;
            SearchMethods = new Dictionary<Options, Func<string, IEnumerable<Customer>>>()
            {
                [Options.ByCountry] = GetByCountry,
                [Options.ByCompanyName] = GetByCompanyName,
            };
        }
        public IEnumerable<Customer> GetByCountry (string countryName)
        {
            return Context.Customers
               .Where(c => c.Country.ToLower().Contains(countryName.ToLower()))
               .ToList();
        }
        
        public IEnumerable<Customer> GetByCompanyName (string companyName)
        {
            return Context.Customers
                .Where(c => c.CompanyName.ToLower().Contains(companyName.ToLower()))
                .ToList()
        }
    }

    public class MyViewModel
    {
        private IRealmCollection<BlogEntry> _blogEntries;
        private IEnumerable<Customer> _customers;
        public IEnumerable<Customer> Customers
        {
            get { return _customers; }
            set { Set(ref _customers, value); }
        }
        public MyViewModel
        {
            Customers = realm.All<Customer>()
                             .AsEnumerable()
                             .Where(c => !c.BlogEntries.Any())
                             .ToArray();
            _blogEntries = realm.All<BlogEntry>().AsRealmCollection();
            _blogEntries.CollectionChanged += (s, e) =>
            {
                var updatedCustomers = realm.All<Customer>()
                                            .AsEnumerable()
                                            .Where(c => !c.BlogEntries.Any())
                                            .ToArray();
                if (!IsEquivalent(updatedCustomers, Customers))
                {
                    Customers = updatedCustomers;
                }
            };
        }
        private bool IsEquivalent(Customer[] a, Customer[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (var i = 0; i < a.Length; i++)
            {
                if (!a[i].Equals(b[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }

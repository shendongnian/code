    public class Search
    {
        private CustomerIdFilter customerfilter;
    
        public CustomerIdFilter CustomerFilter
        {
            set { customerfilter = value; }
        }
    }
    
    var search = new Search();
    search.CustomerFilter = new CustomerIdFilter(1);

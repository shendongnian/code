    public class Customer
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
    public class Search
    {
        private Expression<Func<Customer, bool>> customerfilter;
    
        public Expression<Func<Customer, bool>> CustomerFilter
        {
            set { customerfilter = value; }
        }
    }
    
    var search = new Search();
    search.CustomerFilter = (x => x.Id == 1);

    class DistinctItemComparer : IEqualityComparer<Customer> 
    {
        public bool Equals(Customer x, Customer y) 
        {
            return x.Cods.Intersect(y.Cods).Any();
        }
        public int GetHashCode(Customer obj) 
        {
            return 0;
        }
    }

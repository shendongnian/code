    class CustomerIdFilter // note: this will not replace your existing CustomerFilter which I have renamed to Customer
    {
        public CustomerIdFilter(int id){ ComparisonId = id; }
        public int ComparisonId{ get; private set}
        // To filter use this
        public bool IsValid(Customer c){ return c.Id == ComparisonId; }
        // or maybe something similar to this, if necessary
        public Expression<Func<Customer, bool>>FilterExpression
        {
            get
            {
                return (x=>x.Id == ComparisonId);
            }
        } 
    }

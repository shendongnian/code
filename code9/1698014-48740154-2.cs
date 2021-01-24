    class Insurance
    {
        private int customers;
    
        public Insurance(string agent, int customers)
        {
            Agent = Agent;
            Customers = Customers;
        }
    
        public string Agent { get; set; }
    
        public int Customers
        {
            get { return customers; }
            set { customers = Math.Max(value, 0); }
        }
    }

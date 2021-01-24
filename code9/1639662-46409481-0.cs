        public RPGContext()
            : base("RPGContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
    public Customer()
            {
                AccountNumber = "1345346456444398";
                CustomerName = "Stark Industries";
                UserId = 1;
            }
    public CustomerBillLocation()
            {
                Addresses = new List<Address>();
            }
    public Address()
            {
                Address1 = "Wayne Manor Dr.";
                City = "Gotham";
                Zip = "55555";
                IsDefault = true;
    
            }

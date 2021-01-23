    class CustomerProxy 
    { 
        public CustomerProxy(Customer c, RestService svc)
        {
        }
        public string GetName() 
        {
            return svc.GetName(c.Id);
        }
    }

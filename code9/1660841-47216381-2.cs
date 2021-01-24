    public class Customer
    {
        public int CustNum { get; set; }
        public string OtherAddress { get; set; }
    }
    public class Orders
    {
        public Orders(/* ..other parameters.. */ Customer[] customers)
        {
            this.Customer = customers;
        }
        public Customer[] Customer { get; set; }
    }

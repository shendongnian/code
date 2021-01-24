    public class Customer
    {
        public int CustNum { get; set; }
        public string OtherAddress { get; set; }
    }
    public class Orders
    {
        public Orders(/* ..other parameters.. */ Customer[] customers)
        {
            this.CustomersArray = customers;
        }
        // I use name CustomersArray instead of Customer to make the answer
        // easier to read
        public Customer[] CustomersArray { get; set; }
    }

    public class OrderCustomer {
    
        public OrderCustomer () {
            Order = new Order();
        }
    
        public Order Order { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

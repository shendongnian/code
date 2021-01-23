     public class Order
        {
            public int Id {get; set;}
            public int CustomerId {get; set;}
            public virtual Category Category {get; set;}
            public virtual ICollection <OrderLine> OrderLines {get; set;}
        
            //Many more properties...
        }
        
    public class OrderLine
    {
        public int Id {get; set;}
        public int OrderId {get; set;}
        public virtual Order Order {get; set;}
        public virtual Product Product {get; set;}
        //Other properties...
    }
    
    public class CustomerOrder
    {
        public int CustomerId {get; set;}
        public int OrderId {get; set;}
        public string ProductName {get; set;}
        public virtual ICollection<OrderLine> OrderLines {get; set;}
    }

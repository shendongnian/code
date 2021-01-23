       public class Order     
       { 
            public int Id { get; set; }
            public int AddressId { get; set; }
            public string DeliveryNotes { get; set; }
            public int PurchaseOrderNo { get; set; }
            public virtual  ICollection<OrderItem> Items { get; set; }
         }
        public class OrderItem 
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public decimal UserPrice { get; set; }
            public string Comment { get; set; }    
            [ForeignKey("OrderId ")]
            public int OrderId { get; set; }    
            public virtual Order Order { get; set; }
         }

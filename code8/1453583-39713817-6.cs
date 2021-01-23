    using System;
    using System.Collections.Generic;
    
    namespace Sample
    {
        public class ReportModel
        {
            public string CustomerName { get; set; }
            public DateTime Date { get; set; }
            public List<OrderItem> OrderItems { get; set; }
        }
        public class OrderItem
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Count { get; set; }
        }
    }

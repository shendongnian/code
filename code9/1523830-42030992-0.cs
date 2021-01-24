    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Order> session = new List<Order>();
                var q = session.Where(o => o.ClientName.StartsWith("Jho") && o.Items.Select(i => i.ProductCode == "Book" && i.Quantity >= 10).Any()).ToList();
            }
        }
     
        public class Order
        {
            public string ClientName { get; set; }
            public List<OrderItem> Items { get; set; }
        }
        public class OrderItem
        {
            public string ProductCode { get; set; }
            public int Quantity { get; set; }
        }
    }

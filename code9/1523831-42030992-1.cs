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
                List<Order> session = new List<Order>() {
                    new Order() { ClientName = "Jho", Items = new List<OrderItem>() { 
                            new OrderItem() { ProductCode = "abc", Quantity = 1},
                            new OrderItem() { ProductCode = "def", Quantity = 4},
                            new OrderItem() { ProductCode = "Book", Quantity = 5},
                            new OrderItem() { ProductCode = "jkl", Quantity = 10}
                       }
                    },
                    new Order() { ClientName = "Mary", Items = new List<OrderItem>() { 
                            new OrderItem() { ProductCode = "mno", Quantity = 2},
                            new OrderItem() { ProductCode = "pqr", Quantity = 3},
                            new OrderItem() { ProductCode = "stu", Quantity = 4},
                            new OrderItem() { ProductCode = "vwx", Quantity = 5}
                        }
                    },
                    new Order() { ClientName = "Jho", Items = new List<OrderItem>() { 
                            new OrderItem() { ProductCode = "abc", Quantity = 28},
                            new OrderItem() { ProductCode = "cdf", Quantity = 7},
                            new OrderItem() { ProductCode = "Book", Quantity = 26},
                            new OrderItem() { ProductCode = "jkl", Quantity = 5}
                        }
                    }
                };
                var q = session.Where(o => o.ClientName.StartsWith("Jho") && o.Items.Where(i => i.ProductCode == "Book" && i.Quantity >= 10).Any()).ToList();
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

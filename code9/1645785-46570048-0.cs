        public class Product
        {
            public decimal Price { get; set; }
        }
        public class Item
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
            public decimal TotalAmouint
            {
                get
                {
                    //Maybe you want validate that the product is not null here.
                    return Product.Price * Quantity;
                }
            }
        }

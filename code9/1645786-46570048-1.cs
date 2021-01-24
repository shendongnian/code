        public class Product
        {
            public decimal Price { get; set; }
        }
        public class Item
        {
            public Product Product { get; set; }
            public int Quantity { get; set; }
            public decimal TotalAmount
            {
                get
                {
                    // Maybe you want validate that the product is not null here.
                    // note that "Product" here refers to the property, not the class
                    return Product.Price * Quantity;
                }
            }
        }

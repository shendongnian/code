        class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public string Region { get; set; }
            public List<Price> Prices { get; set; }
        }
        class Price
        {
            public int Year { get; set; }
            public decimal Amount { get; set; }
        }

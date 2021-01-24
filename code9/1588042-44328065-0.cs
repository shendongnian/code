    class Product
            {
                public string Name { get; set; }
                public string Category { get; set; }
                public string Region { get; set; }
                public IDictionary<int, decimal> PricePerYear { get; set; } 
                    = new Dictionary<int, decimal>( );
            }
    var prod = new Product
                       {
                           Name = "Product1",
                           Category = "TV",
                           Region = "China",
                       };
            prod.PricePerYear.Add( 2016, 2000 );
            prod.PricePerYear.Add( 2017, 4500 );

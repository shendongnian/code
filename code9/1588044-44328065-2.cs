      class Product
      {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Region { get; set; }
        public IList<(int price, decimal amount)> PricePerYear { get; set; } = 
            new List<(int price, decimal amount)>();
      }
    var prod = new Product
                       {
                           Name = "Product1",
                           Category = "TV",
                           Region = "China",
                       };
            prod.PricePerYear.Add( (2016, 4500) );
            // HDR 8K TV..
            prod.PricePerYear.Add( (2017, 10000) );
            (int year, decimal price) = prod.PricePerYear.FirstOrDefault( );
            Console.WriteLine( $"Year: {year} Price: {price}" );
            Console.ReadLine( );

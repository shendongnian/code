    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Region { get; set; }
        public IList<(int year, decimal amount)> PricePerYear { get; set; }
    }
    
     var prod = new Product
                           {
                               Name = "Product1",
                               Category = "TV",
                               Region = "China",
                               PricePerYear = new List<(int year, decimal amount)>
                                              {
                                                  (year: 2016, amount: 5000),
                                                  (2017, 10000),
                                                  (2018, 5000),
                                              }
                           };
                (int year, decimal price) = prod.PricePerYear.First( );
                Console.WriteLine( $"Year: {year} Price: {price}" );
                Console.ReadLine( );

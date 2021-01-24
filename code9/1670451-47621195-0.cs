    class Product
    {
       long Id { get; set; }
       string Name { get; set; }
       virtual ProductCategory ProductCategory { get; set; }
    }

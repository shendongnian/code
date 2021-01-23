    List<Product> Products = new List<Product>()
    {
       new Product() { Id = 1, Name = "A", CategoryId = 11, SectionId = 6, VendorName = "ABC" },
       new Product() { Id = 2, Name = "B", CategoryId = 21, SectionId = 6, VendorName = "ABC" },
       new Product() { Id = 3, Name = "C", CategoryId = 13, SectionId = 8, VendorName = "ABC" },
       new Product() { Id = 4, Name = "D", CategoryId = 90, SectionId = 6, VendorName = "ABC" },
       new Product() { Id = 5, Name = "E", CategoryId = 25, SectionId = 9,    VendorName = "ABC" },
    };
    List<Product> catsRemoved = Products.Where(x => x.CategoryId != 11 && x.CategoryId != 90).ToList();

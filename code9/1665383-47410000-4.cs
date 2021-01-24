    List<Product> lstProducts = new List<Product>();
    lstProducts.Add(new Product()
    {
        ProductID = 1001,
        Name = "Product1",
        Categories = new List<Category>()
        {
            new Category(){
                Name ="Category1",
                Settings =new Dictionary<string, string>{
                    { "SettingA", "val1" },
                    { "SettingB", "val2" } }
            },
            new Category(){
                Name ="Category2",
                Settings =new Dictionary<string, string>{
                    { "SettingA", "val1" },
                    { "SettingB", "val2" } }
            },
    
        }
    });

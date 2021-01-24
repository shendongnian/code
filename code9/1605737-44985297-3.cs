    public string SerializeProductConfig()
    {
       ProductConfig pc = new ProductConfig();
       pc.Config = new Config { token = "DDTest", site = "US", mode = "Test Mode" };
       pc.Products = new List<Products>();
       pc.Products.Add(new Products() { product_id = "1", title = "Bryon Hetrick", price = "50" });
       pc.Products.Add(new Products() { product_id = "2", title = "Nicole Wilcox", price = "20" });
       var serializer = new JavaScriptSerializer();
       return serializer.Serialize(pc);
    }

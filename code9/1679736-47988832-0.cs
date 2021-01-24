    public class Product
    {
        public long ProductIid {get;set;}
        public string Mark {get;set;}
        public string Position {get;set;}
        public Product[] ChildProduct {get;set;}
    }
    var data = JsonConvert.DeserializeObject<Product[]>(responseData);

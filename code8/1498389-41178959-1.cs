    public class Product
    {
        public int ID {get;set;}
        public string Name {get;set;}
        public string Size {get;set;}
        public decimal Price {get;set;}
        public string Image {get;set;}
        public int Quantity {get;set;}
    }
    Dictionary<int, Product> dicProducts = new Dictionary<int, Product>();
    string[] products = cookieValue.Split('&');
    var len = products.Length;                             
    int half = len / 2;
    for(int x=half;x<len;x++)
    {
        string[] productData = products[x].Split(',');
        Product p = new Product()
        {
  
            ID = Convert.ToInt32(productData[0]);
            Name = productData[1];
            Size = productData[2];
            Price = Convert.ToDecimal(productData[3]);
            Image = productData[4];
            Quantity = Convert.ToInt32(productData[5]);
        }
        dicProducts.Add(p.ID, p);
    }

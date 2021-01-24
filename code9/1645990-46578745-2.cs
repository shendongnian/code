    public class MixedProduct {
        public List<Products> Products {get; set;}
        public List<ProductList> ProductList {get; set;}
    }
    var products= JsonConvert.SerializeObject(new MixedProduct { Products = A, ProductList = B}, Formatting.Indented);

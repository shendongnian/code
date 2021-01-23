     public enum ProductType
        {
            Bottom=0,
            Medium,
            Top,
        }
    
        public class Product
        {
            public ProductType Type { get; set; }
            //the rest of properties here
        }
     var list = new List<Product>();
     var orderedList = list.OrderBy(x => (int)x.Type).ToList();

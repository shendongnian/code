    public class ProductA
    { 
        public string Name { get; set; }
        public int ID { get; set; }
    }
    
    public class ProductComparer : IEqualityComparer<ProductA>
    {
    
        public bool Equals(ProductA x, ProductA y)
        {
            //Check whether the objects are the same object. 
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether the products' properties are equal. 
            return x.ID== y.ID;
        }
    
        public int GetHashCode(ProductA obj)
        {
            //Get hash code for the ID field. 
            return obj.Code.GetHashCode();
        }
    }

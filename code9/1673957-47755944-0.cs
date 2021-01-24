    // This class defines your objects with your properties.
    public class ProductA
    { 
        public string Name { get; set; }
        public int Code { get; set; }
    }
    // This class is used for custom comparison.
    public class ProductComparer : IEqualityComparer<ProductA>
    {
    
        public bool Equals(ProductA x, ProductA y)
        {
            //Check whether the objects are the same object. 
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether the products' properties are equal. 
            return x != null && y != null && x.Code.Equals(y.Code) && x.Name.Equals(y.Name);
        }
    
        public int GetHashCode(ProductA obj)
        {
            int hashProductName = obj.Name == null ? 0 : obj.Name.GetHashCode();
            int hashProductCode = obj.Code.GetHashCode();
            return hashProductName ^ hashProductCode;
        }
    }

     public class ProductDetails
        { 
            public string id {get; set;}
            public string description {get; set;}
            public float rate {get; set;}
        }
    public class ProductComparer : IEqualityComparer<ProductDetails>
    {
    
        public bool Equals(ProductDetails x, ProductDetails y)
        {
            //Check whether the objects are the same object. 
            if (Object.ReferenceEquals(x, y)) return true;
    
            //Check whether the products' properties are equal. 
            return x != null && y != null && x.id.Equals(y.id) && x.description.Equals(y.description);
        }
    
        public int GetHashCode(ProductDetails obj)
        {
            //Get hash code for the description field if it is not null. 
            int hashProductDesc = obj.description == null ? 0 : obj.description.GetHashCode();
    
            //Get hash code for the idfield. 
            int hashProductId = obj.id.GetHashCode();
    
            //Calculate the hash code for the product. 
            return hashProductDesc ^ hashProductId ;
        }
    }

    public class ProductDetails
    {
        public string id;
        public string description;
        public float rate;
    
        public override bool Equals(object obj)
        {
            var p = obj as ProductDetails;
            return ReferenceEquals(p, null) ? false : description == obj.description;
        }
    
        public override int GetHashCode() => description.GetHashCode();    
    }

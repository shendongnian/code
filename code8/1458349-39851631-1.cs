    public class CustomFormat : IEquatable<CustomFormat>
    {
        public string Mask { get; set; }
        public int Type { get; set; }
        
        public CustomFormat(string mask, int type)
        {
            Mask = mask;
            Type = type;
        }
        
        public bool Equals(CustomFormat other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other != null && other.Mask == Mask && other.Type == Type;
        }
        
        public override bool Equals(object obj)
        {
            return Equals(obj as CustomFormat);
        }
        
        public override int GetHashCode()
        {
            // Get hash code for the Name field if it is not null. 
            int hashProductName = Mask == null ? 0 : Mask.GetHashCode();
            
            //Get hash code for the Code field. 
            int hashProductCode = Type.GetHashCode();
            
            //Calculate the hash code for the product. 
            return hashProductName ^ hashProductCode;
        }
    }

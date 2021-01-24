    public class Farmer : IEquatable<Farmer>
    {
        public string FarmerName { get; set; }
        // .... other properties etc
        
        public bool Equals(Farmer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(FarmerName, other.FarmerName);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Farmer) obj);
        }
        public override int GetHashCode()
        {
            return (FarmerName != null ? FarmerName.GetHashCode() : 0);
        }
    }

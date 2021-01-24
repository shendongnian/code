    public class Farmer : IEquatable<Farmer>
    {
        public string FarmerName { get; set; }
        public string ContractNumber { get; set; }
        // .... other properties etc
        public bool Equals(Farmer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(ContractNumber, other.ContractNumber);
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
            return (ContractNumber != null ? ContractNumber.GetHashCode() : 0);
        }
    }

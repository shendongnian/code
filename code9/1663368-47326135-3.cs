    public class FarmerContractComparer : IEqualityComparer<Farmer>
    {
        public bool Equals(Farmer x, Farmer y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(null, x) || ReferenceEquals(null, y)) return false;
            return x.ContractNumber == y.ContractNumber;
        }
        public int GetHashCode(Farmer obj)
        {
            return (obj.ContractNumber != null ? obj.ContractNumber.GetHashCode() : 0);
        }
    }public class FarmerContractComparer : IEqualityComparer<Farmer>
    {
        public bool Equals(Farmer x, Farmer y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(null, x) || ReferenceEquals(null, y)) return false;
            return x.ContractNumber == y.ContractNumber;
        }
        public int GetHashCode(Farmer obj)
        {
            return (obj.ContractNumber != null ? obj.ContractNumber.GetHashCode() : 0);
        }
    }

    public class Comparer : IEqualityComparer<StatusType>
    {
        public bool Equals(StatusType x, StatusType y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(StatusType obj)
        {
            return obj.Id.GetHashCode();
        }
    }

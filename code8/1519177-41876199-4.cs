    public class ListComparer : IEqualityComparer<IInterface>
    {
        public bool Equals(IInterface x, IInterface y)
        {
            return x.X == y.X && x.Y == y.Y;
        }
        public int GetHashCode(IInterface obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 * obj.X.GetHashCode();
                hash = hash * 23 * obj.Y.GetHashCode();
                return hash;
            }
        }
    }

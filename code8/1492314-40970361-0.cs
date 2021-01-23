    public class ConnectionDetailEqualityComparer : IEqualityComparer<ConnectionDetail>
    {
        public bool Equals(ConnectionDetail x, ConnectionDetail y)
        {
            return x.SyID == y.SyID && x.PtID == y.PtID && x.Usage == y.Usage;
        }
        public int GetHashCode(ConnectionDetail obj)
        {
            return obj.SyID.GetHashCode() ^ obj.PtID.GetHashCode() ^ obj.Usage.GetHashCode();
        }
    }

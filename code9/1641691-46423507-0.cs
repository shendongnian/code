    public class CREntityComparer : IEqualityComparer<CREntity>
    {
        public bool Equals(CREntity x, CREntity y)
        {
            if (x != null && y != null && x.C_ID.Equals(y.C_ID))
                return true;
            return false;
        }
        public int GetHashCode(CREntity obj)
        {
            if (obj == null)
                return -1;
            return obj.C_ID.GetHashCode();
        }
    }

    public class InfoComparer : IEqualityComparer<InfoForGraph>
    {
        public bool Equals(InfoForGraph x, InfoForGraph y)
        {
            if (x.b == y.b && x.c == y.c)
                return true;
            else
                return false;
        }
        public int GetHashCode(InfoForGraph obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + obj.b.GetHashCode();
                hash = hash * 23 + obj.c.GetHashCode();
                return hash;
            }
        }
    }

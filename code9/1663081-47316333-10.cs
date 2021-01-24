    public class OT_ContactEqualityComparer : IEqualityComparer<OT_Contact>
    {
        public bool Equals(OT_Contact x, OT_Contact y)
        {
            if (x == null || y == null)
                return false;
            return (x.Name == y.Name && x.Email == y.Email); 
        }
        public int GetHashCode(OT_Contact c)
            => (c.Name ?? "").GetHashCode() ^ (c.Email ?? "").GetHashCode(); 
    }

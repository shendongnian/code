    public class OppositePointEqualComparer : IEqualityComparer<Location>
    {
        public bool Equals(Location l1, Location l2)
        {
            if (object.ReferenceEquals(l1, l2)) return true;
            if (l1 == null || l2 == null) return false;
            return (l1.X == l2.X && l1.Y == l2.Y) || (l1.X == l2.Y && l1.Y == l2.X);
        }
        public int GetHashCode(Location l)
        {
            if(l == null) return int.MinValue;
            return Math.Abs(l.X - l.Y);
        }
    }

    public class GroupingComparer : IEqualityComparer<DateTime>
    {
        private readonly int _offset;
    
        public GroupingComparer(int offset)
        {
            _offset = offset;
        }
    
        public bool Equals(DateTime x, DateTime y)
        {
            if (y.Second >= x.Second - _offset && y.Second <= x.Second + _offset) return true;
    
            return false;
        }
    
        public int GetHashCode(DateTime obj)
        {
            //Should most probably look at a better way to get the hashcode.
            return obj.ToShortDateString().GetHashCode();
        }
    }

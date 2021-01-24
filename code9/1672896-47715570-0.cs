    public class ProcessIdComparer : IEqualityComparer<System.Diagnostics.Process>
    {
        public bool Equals(Process x, Process y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.Id == y.Id;
        }
        public int GetHashCode(Process obj)
        {
            return obj?.Id.GetHashCode() ?? 0;
        }
    }

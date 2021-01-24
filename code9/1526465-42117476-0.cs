    public class EqualityComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            IDictionary<string, object> xP = x as IDictionary<string, object>;
            IDictionary<string, object> yP = y as IDictionary<string, object>;
            if (xP.Count != yP.Count)
                return false;
            if (xP.Keys.Except(yP.Keys).Any())
                return false;
            if (yP.Keys.Except(xP.Keys).Any())
                return false;
            foreach (var pair in xP)
                if (pair.Value.Equals( yP[pair.Key])==false)
                    return false;
            return true;
        }
        public int GetHashCode(T obj)
        {
            return obj.ToString().GetHashCode();
        }
    }

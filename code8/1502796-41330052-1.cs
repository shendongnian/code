    public class tr_comparer: IEqualityComparer<tr>
    {
        public bool Equals(tr x, tr y)
        {
            return x.tr_key == y.tr_key;
        }
        public int GetHashCode(tr obj)
        {
            return obj.tr_key.GetHashCode();
        }
    }

    public class CustomSort : IComparer<string>
    {
        public const string Order = "AEIOUFGLMNPSTVHKR";
        public int Compare(string a, string b)
        {
            if (a == null)
            {
                return b == null ? 0 : -1;
            }
            if (b == null)
            {
                return 1;
            }
            int minLength = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minLength; i++)
            {
                int i1 = Order.IndexOf(a[i]);
                int i2 = Order.IndexOf(b[i]);
                if (i1 == -1)
                {
                    throw new Exception(a);
                }
                if (i2 == -1)
                {
                    throw new Exception(b);
                }
                int cmp = i1.CompareTo(i2);
                if (cmp != 0)
                {
                    return cmp;
                }
            }
            return a.Length.CompareTo(b.Length);
        }
    }

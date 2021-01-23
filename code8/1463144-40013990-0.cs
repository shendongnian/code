    public class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            if (x.All(char.IsDigit) && y.All(char.IsDigit))
            {
                var n1 = Convert.ToInt32(x);
                var n2 = Convert.ToInt32(y);
                return n1 - n2;
            }
            return x.CompareTo(y);
        }
    }

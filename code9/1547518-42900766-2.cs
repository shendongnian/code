    public class WhitespaceInsensitiveComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Join("", x.Where(m => !char.IsWhiteSpace(m))) == string.Join("", y.Where(m => !char.IsWhiteSpace(m)));
        }
        public int GetHashCode(string x)
        {
            return string.Join("", x.Where(m => !char.IsWhiteSpace(m))).GetHashCode();
        }
    }
        

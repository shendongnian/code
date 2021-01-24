    public class FileNameEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            return x != null && y != null && Path.GetFileName(x) == Path.GetFileName(y);
        }
        public int GetHashCode(string obj)
        {
            return Path.GetFileName(obj).GetHashCode();
        }
    }

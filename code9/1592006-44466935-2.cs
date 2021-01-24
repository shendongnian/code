    private class NearMatchComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return string.Compare(x, y) < 2;
        }
    
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

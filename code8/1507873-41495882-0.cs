    class CustomComparer : EqualityComparer<string>
    {
        public override bool Equals(string x, string y)
        {
            if (x == "border" || y == "border") return false;
            return Default.Equals(x, y);
        }
        public override int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }

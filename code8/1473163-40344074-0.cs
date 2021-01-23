    public override int GetHashCode()
    {
        unchecked
        {
            int hash = KeyNumber * 397;
            foreach (var opt in Options)
            {
                hash = hash*23 + opt.x.GetHashCode();
                hash = hash*23 + opt.y.GetHashCode();
            }
            return hash;
        }
    }

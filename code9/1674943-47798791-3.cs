    public class FooBar 
    {
        public int FooBarValue { get; set; }
    }
    public class FooBarComparer : IEqualityComparer<FooBar>
    {
        public bool Equals(FooBar x, FooBar y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.FooBarValue == y.FooBarValue;
        }
        public int GetHashCode(FooBar obj)
        {
            return obj.GetHashCode();
        }
    }

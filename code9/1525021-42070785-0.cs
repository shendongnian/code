    class Comparer : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            return x.a == y.a && x.c == y.c && x.f == y.f;
        }
        public int GetHashCode(MyObject obj)
        {
            return (obj.a + obj.c + obj.f).GetHashCode();
        }
    }
 

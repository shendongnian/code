    class PersonEqualityComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            dynamic d1 = x, d2 = y;
            return d1.PersonID == d2.PersonID && d1.Name == d2.Name;
        }
        public int GetHashCode(T obj)
        {
            dynamic d = obj;
            // ...or whatever your favorite hash code aggregation technique is here
            return d.PersonID.GetHashCode() * 37 + d.Name.GetHashCode();
        }
    }

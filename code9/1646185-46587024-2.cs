    public class PersonNameComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            if(object.ReferenceEquals(x, y)) return true;
            return x.Name == y.Name;
        }
        public int GetHashCode(Person obj)
        {
            return obj?.Name?.GetHashCode() ?? int.MinValue;
        }
    }

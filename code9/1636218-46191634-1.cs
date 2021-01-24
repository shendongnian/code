    public sealed class NameAndAddressComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
            {
                return false;
            }
            return x.Name == y.Name && x.Address == y.Address;
        }
        public int GetHashCode(Person person) =>
            ReferenceEquals(person, null) ? 0
            : 23 * person.Name.GetHashCode() + person.Address.GetHashCode();
    }

    public sealed class NameAndAddressComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y) =>
            x.Name == y.Name && x.Address == y.Address;
        public int GetHashCode(Person person) =>
            23 * person.Name.GetHashCode() + person.Address.GetHashCode();
    }

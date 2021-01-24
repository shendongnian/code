    //Union the persons and use the comparer class
    var result =   persons.Union(persons, new PersonComparer()).Where(e=> !string.IsNullOrEmpty( e.comment));
    //Use the below comparer class
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }
        public int GetHashCode(Person obj)
        {
            return obj.FirstName.GetHashCode() + obj.LastName.GetHashCode();
        }
    }

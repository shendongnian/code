    class Person
    {
        public string FirstName {get; set;}
        public string FamilyName {get; set;}
    }
    // create a comparer that will put Persons without firstName last:
    IComparer<Person> myComparer =
        NullValueLastComparer<Person, string>.Create(person => person.FirstName);
    Person person1 = ...;
    Person person2 = ...;
    int compareResult = myComparer.Compare(person1, person2);

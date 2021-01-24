    class Person
    {
        public string FirstName {get; set;}
        public string FamilyName {get; set;}
    }
    // create a comparer that will put Persons without firstName last
    IComparer<Person> myComparer = NullValueLastComparer<Person, string>.Create(person => person.FirstName);

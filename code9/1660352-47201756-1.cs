    public class Person : RealmObject
    {
        // ... other props
        [Backlink(nameof(Dog.Person))]
        public IQueryable<Dog> Dogs { get; }
    }
    public class Dog : RealmObject
    {
        // ... other props
        public Person Person { get; set; }
    }

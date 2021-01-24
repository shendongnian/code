    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
    }
    var person = new Person
    {
        FirstName = "Foo",
        LastName = "Bar",
        Gender = Gender.Male
    };

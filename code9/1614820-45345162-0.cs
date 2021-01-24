    public class Person
    {
        public Person()
        {
            Children = new List<Person>();
        }
        public Person(string firstName)
            : this()
        {
            this.FirstName = firstName;
        }
        public Person(string firstName, string lastName)
            : this(firstName)
        {
            this.LastName = lastName;
        }
        public string FirstName { get; }
        public string LastName { get; }
        public IEnumerable<Person> Children { get; }
    }

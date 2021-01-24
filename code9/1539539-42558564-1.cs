    public class Person
    {
        private Person() //for EF
        {
        }
        public Person(string name) //for me
        {
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
    }

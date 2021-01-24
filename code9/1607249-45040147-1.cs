    public class Person
    {
        public Person(string name) : this(name, 0) // will call constructor with two arguments
        { }
        public Person(string name, string id)
        {
            Name = name;
            Id = id;
        }        
    }
 

    public class Person 
    {
        public string Name { get; private set; }
        
        public Person(string name)
        {
            Name = name;
        }
        
        protected Person() { }
    }

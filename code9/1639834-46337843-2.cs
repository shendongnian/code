    public class Person
    {
        private string last;
        private string first;
        
        // This constructor is called a default constructor.
        // If you put nothing in it, it will just instanciate an object
        // and set the default value for each field: for a reference type,
        // it will be null for instance. String is a reference type, 
        // so both last and first will be null.
        public Person()
        {}
        // This constructor will instanciate an object an set the last and first with string you provide.
        public Person(string lastName, string firstName)
        {
            last = lastName;
            first = firstName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           // last and first will be null for myPerson1.
           Person myPerson1 = new Person();
           // last = Doe and first = John for myPerson2.
           Person myPerson2 = new Person("Doe", "John");
        }
    }

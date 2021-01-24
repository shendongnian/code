    public class Person
    {
        private string last;
        private string first;
    
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
           Person myPerson = new Person("John", "Doe");
        }
    }

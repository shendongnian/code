    public interface IPeopleRepository :  IEnumerable<Person>
        {
            void AddPerson(Person person);
        }
    
        public class Repository
        {
            // Singleton isolated to here...
           public static Repository Of { get; } =
                new Repository() { People = new PeopleRepsository()};
    
           public IPeopleRepository People { get; private set; }       
        }
    
        public class PeopleRepsository : IPeopleRepository
        {
            private List<Person> People { get; set; } = new List<Person>();
            public IEnumerator<Person> GetEnumerator()
            {
                return People.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public void AddPerson(Person person)
            {
                if(person!= null) People.Add(person);
            }
        }
    
    
        public class Person
        {
            public Person(string name, string details)
            {
                this.Name = name;
                this.Details = details;
            }
    
            public string Name { get; private set; }
            public string Details { get; private set; }
            public override string ToString()
            {
                return $"{Name} : {Details}";
            }
        }
    
        public class Foo
        {
            private readonly IPeopleRepository _people;
    
            public Foo(IPeopleRepository people)
            {
                _people = people;
            }
    
            public void Bar()
            {
                _people.AddPerson(new Person("Foo", "Bar"));
                _people.ToList().ForEach(Console.WriteLine);
            }
        }
    
       
        class Program
        {
            static void Main(string[] args)
            {
                // you can get it here.
                Repository.Of.People.AddPerson(new Person("hi", "there"));
                
                // but instead of using it everywhere... inject it where you can
                var foo = new Foo(Repository.Of.People);
                foo.Bar();
    
    
            }        
        }

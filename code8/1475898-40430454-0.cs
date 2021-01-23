    namespace MyPersonNamespace
    {
        public static class PersonExtensions
        {
            public static T Get<T>(this Person person, string name)
            {
                return (T)person.NewFirstName(name);
            }
        }
    
        public class Person
        {    
            public Person(string firstName)
            {
                this.FirstName = firstName;
            }
    
            public string FirstName {get; private set;}
            public string LastName {get; set;}
    
            public object NewFirstName(string name)
            {
                this.FirstName = name;
                return (object) this.FirstName;
            }        
        }  
    }

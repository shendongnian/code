    namespace NamespaceOne
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
    
    namespace NamespaceTwo
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
    
    namespace MainNamespace
    {
        class Program
        {
            public static void Main()
            {
                NamespaceOne.Person p1 = new NamespaceOne.Person() { FirstName = "Zaphod", LastName = "Beeblebrox" };
                NamespaceTwo.Person p2 = new NamespaceTwo.Person() { FirstName = p1.FirstName, LastName = p1.LastName };
    
                Console.ReadLine();
            }
        }
    }

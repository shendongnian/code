    namespace CommonNamespace
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
                CommonNamespace.Person p1 = new CommonNamespace.Person() { FirstName = "Zaphod", LastName = "Beeblebrox" };
                CommonNamespace.Person p2 = p1;
                
                Console.ReadLine();
            }
        }
    }

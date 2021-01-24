    class Person
        {
            
            private string name, lastname;
    
           public Person(string N, string LN)
            {
                name = N;
                lastname = LN;
    
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
    
            public string Lastname
            {
                get { return lastname; }
                set { lastname = value; }
    
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Person person1 = new Person("Matt", "Houdson");
    
                Console.WriteLine("Name: {0}", person1.Name);
                Console.ReadKey();
    
            }
        }
 

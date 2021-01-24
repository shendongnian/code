    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person(1, "Mario");
            Person p2 = new Person(2, "Franco");
            Dog d1 = new Dog(1, "Fuffy");
            Dog d2 = new Dog(2, "Chop");
            List<Person> listP = new List<Person>();
            listP.Add(p1);
            listP.Add(p2);
            List<Dog> listD = new List<Dog>();
            listD.Add(d1);
            listD.Add(d2);
            List<Object> listO = new List<Object>();
            listO.Add(listP);
            listO.Add(listD);
        }
        public class Person
        {
            public Person(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public int id { get; set; }
            public string name { get; set; }
        }
        public class Dog
        {
            public Dog(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public int id { get; set; }
            public string name { get; set; }
        }
    }

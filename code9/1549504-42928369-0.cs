    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person(1, "abc");
            Person p2 = new Person(2, "vbn");
            List<Person> list = new List<Person>();
            list.Add(p1);
            list.Add(p2);
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
    }

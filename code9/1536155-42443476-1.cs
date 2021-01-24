    class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public static void DoSomething()
        {
            var people = new List<Person>();
            var dict = people.ToDictionary(p => p.ID);
        }

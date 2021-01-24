    class People
    {
        public List<Person> Persons { get; set; }
        public string Names
        {
            get
            {
                return String.Join(",", Persons.Select(p => p.Name));
            }
        }
    }
    
    class Person
    {
        public string Name { get; set; }
    }

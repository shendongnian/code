    class People
    {
        public List<Person> Persons { get; set; }
        public string Names
        {
            get
            {
                if (Persons != null)
                {
                    return String.Join(",", Persons.Select(p => p.Name));
                }
                else 
                {
                    return string.Empty;
                }
            }
        }
    }
    
    class Person
    {
        public string Name { get; set; }
    }

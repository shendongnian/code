    class Person
    {
        public Person()
        {
            Children = new List<Person>();
        }
        public List<Person> Children { get; set; }
        [SensitiveData]
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [SensitiveData]
        public string SocialSecurityNumber { get; set; }
        public Person Spouse { get; set; }
    }

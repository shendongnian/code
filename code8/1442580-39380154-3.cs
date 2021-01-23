    class HumanName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    class Human
    {
        public HumanName Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }

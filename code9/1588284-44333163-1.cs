    class Child
    {
        public int Id {get; set;}
        // this is required if you want do it in a single operation
        public int SchoolId { get; set; }
        // this one is optional
        public School { get; set; }
        ...
    }

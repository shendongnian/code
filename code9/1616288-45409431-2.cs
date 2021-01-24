    class Parent
    {
        public Parent()
        {
            Children = new List<Child>();
        }
        public int Id {get;set;}
        public ICollection<Child> Children { get; set; }
    }
    class Child
    {
        public Child()
        {
            Parents = new List<Parent>();
        }
        public int Id {get;set;}
        public ICollection<Parent> Parents { get; set; }
    }

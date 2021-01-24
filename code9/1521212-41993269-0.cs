    public Parent
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public List<Child> Children { get; set; }
    }
    
    public Child
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Description { get; set; }
    }

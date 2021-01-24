    class Tool
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProjectId {get; set;}
        public virtual Project Project { get; set; }
    }

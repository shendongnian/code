    class Project : Models
    {
        [PrimaryKey]
        public int Id { get; set; }
		
        public string Description { get; set; }
        // The id of the task used in the relationship (this gets stored in the DB)
		[ForeignKey(typeof(Task))]
		public int TaskId { get; set; }
		
        // Meaning you have many projects to one task
        [ManyToOne]
        public Task Task { get; set; }
    }
    class Task : Models
    {
        [PrimaryKey]
        public int Id { get; set; }
		
        public string Description { get; set; }
    }

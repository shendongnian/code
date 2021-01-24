    public class Test
    {
        [PrimaryKey, AutoIncrement]
        public string AnotherID { get; set; }
        public string Name { get; set; }
    }
    public class TodoItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
        [ForeignKey(typeof(Test))]
        public string TestId { get; set; }
        [OneToOne]
        public Test Test { get; set; }
    }

    public class TodoItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Notes { get; set; }
		public bool Done { get; set; }
        [TextBlob("StringsBlobbed")]
        public List<string> Strings { get; set; }
        public string StringsBlobbed { get; set; }
    }

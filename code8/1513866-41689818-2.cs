	class Game  
    {
		public Game(int edition, string date, [JsonConverter(typeof(StringEnumConverter))] GameType nameType)
		{
			this.Edition = edition;
			this.Date = date;
			this.NameType = nameType;
			this.Questions = new List<Question>();
		}
				
        public int Edition { get; private set; }
        [JsonIgnore]
        public string Name
	    {
			get
			{
				return NameType.ToString();
			}
		}
		public string Date { get; private set; }
	
		[JsonConverter(typeof(StringEnumConverter))]  
		public GameType NameType { get; private set; } //enum
	
		public List<Question> Questions { get; private set; } //yes, Question is serializable
	}

		public Game(int edition, string date, [JsonConverter(typeof(StringEnumConverter))] GameType nameType) 
			: this(edition, date, nameType, new List<Question>())
		{
		}
		
		[JsonConstructor]		
		public Game(int edition, string date, [JsonConverter(typeof(StringEnumConverter))] GameType nameType, List<Question> questions)
		{
			this.Edition = edition;
			this.Date = date;
			this.NameType = nameType;
			this.Questions = questions;
		}

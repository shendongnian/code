	class Conversation
	{
		public int Id;
		public string Message;
		public int MessageId;
	}
	class Program
	{
		static void Main(string[] args)
		{
			var inputList = new List<Conversation>
			{
				new Conversation() {Id = 1, Message = "asd0", MessageId = 1},
				new Conversation() {Id = 1, Message = "asd1", MessageId = 2},
				new Conversation() {Id = 1, Message = "asd2", MessageId = 3},
				new Conversation() {Id = 2, Message = "asd3", MessageId = 4},
				new Conversation() {Id = 2, Message = "asd4", MessageId = 5},
				new Conversation() {Id = 2, Message = "asd5", MessageId = 6},
				new Conversation() {Id = 3, Message = "asd6", MessageId = 7}
			};
			var outputList = inputList.GroupBy(x => x.Id)
				.SelectMany(x => x.OrderBy(y => y.MessageId).Take(2).ToList())
				.ToList();
			Console.ReadKey();
		}
	}

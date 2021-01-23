	public class Book
	{
		public const string className = "Book";
		public string Id { get; set; }
		public string Name { get; set; }
		public string UserId { get; set; }
		public DateTime DateTime { get; set; }
		public override string ToString()
		{
			return $"Book:    Id: {Id.PadRight(7)} - Name: {Name.PadRight(14)} - DateTime: {DateTime}";
		}
	}
	public class Comment
	{
		public string Id { get; set; }
		public string BookId { get; set; }
		public string UserId { get; set; }
		public string Content { get; set; }
		public DateTime DateTime { get; set; }
		public override string ToString()
		{
			return $"Comment: Id: {Id.PadRight(7)} - Content: {Content.PadRight(11)} - DateTime: {DateTime}";
		}
	}
	class Program
	{
		static void Main()
		{
			try
			{
				string userid = "User1";
				var books = new List<Book>();
				books.Add(new Book { Id = "B1", Name = "Book1", UserId = "User1", DateTime = new DateTime(2016, 11, 16, 11, 15, 00) });
				books.Add(new Book { Id = "B2", Name = "Book2", UserId = "User1", DateTime = new DateTime(2016, 11, 16, 12, 15, 00) });
				books.Add(new Book { Id = "B3", Name = "Book3", UserId = "User2", DateTime = new DateTime(2016, 11, 16, 10, 15, 00) });
				var comments = new List<Comment>();
				comments.Add(new Comment { Id = "c1", BookId = "B3", UserId = "User1", Content = "cmt1", DateTime = new DateTime(2016, 11, 16, 11, 17, 00) });
				comments.Add(new Comment { Id = "c2", BookId = "B1", UserId = "User1", Content = "cmt2", DateTime = new DateTime(2016, 11, 16, 11, 16, 00) });
				var test = (from b in books
							where b.UserId == userid
							let o = (object)b
							select o).Concat(
							from c in comments
							where c.UserId == userid
							let o = (object)c
							select o).OrderBy(x => x.GetType() == typeof(Book)?((Book)x).DateTime:((Comment)x).DateTime);
				foreach(var o in test)
				{
					Console.WriteLine(o);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}

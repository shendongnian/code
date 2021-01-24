    var authorBooks = db.AuthorBook.Include(x => x.Author).Include(x => x.Book).ToList();
	foreach (var author in db.Author)
	{
		Console.WriteLine(author.Name + " has written:");
		if (author.AuthorBook != null)
		{
			var books = author.AuthorBook.Select(x => x.Book).ToList();
			foreach (var book in books)
			{
				Console.WriteLine("- " + book.Title);
			}
		}
		else
		{
			Console.WriteLine(" no books yet");
		}
		Console.WriteLine();
	}

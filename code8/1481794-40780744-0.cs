    public class BooksWithAuthors : AbstractMultiMapIndexCreationTask<BooksWithAuthors.Result>
    {
	    public class Result 
        {
		    string Id;
		    string Title;
		    IEnumerable<string> AuthorIds;
	    }
        public BooksWithAuthors()
        {
            AddMap<Book>(book => from book in books
                                 select new
                                 {
                                     Id = book.Id,
                                     Title = book.Title,
                                     AuthorIds = null;
                                 });
    
            AddMap<Author>(author => from author in authors
        					         from bookId in author.bookIds
                                     select new
                                     {
                                         Id = bookId,
                                         Title = null,
                                         AuthorIds = new List<string>(){ author.Id };
                                     });
    
            Reduce = results => from result in results
                                group result by result.Id
                                into g
                                select new
                                {
                                    Id = g.Key,
                                    Title = g.Select(r => r.Title).Where(t => t != null).First(),
                                    AuthorIds = g.Where(r => r.AuthorIds != null).SelectMany(r => r.AuthorIds)
                                };
        }
    }

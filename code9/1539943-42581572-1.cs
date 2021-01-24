      public class Book
        {
            public Book(string name, IList<Author> authors)
            {
                Name = name;
                Authors = new List<Author>();
                foreach (Author author in authors)
                {
                    author.Books.Add(this);
                    Authors.Add(author);
                }
            }
    
            public string Name { get; set; }
            public List<Author> Authors { get; set; }
        }

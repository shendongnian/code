    public class BookStore
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        
        public static Book GetBook(string name)
        {
            var query = Books.Where(b => b.Name.Equals(name));
            if (query.Count() == 1)
                return query.ElementAt(0);
            else return null;
        }
        
        public static Author GetAuthor(string name)
        {
            var query = Authors.Where(a => a.Name.Equals(name));
            if (query.Count() == 1)
                return query.ElementAt(0);
            else return null;
        }
    }

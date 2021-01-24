    public class Directory 
    {
        public HashSet<Book> Books { get; } 
            = new HashSet<Book>(new BookEqualityComparer());
        //...
        private class BookEqualityComparer : IEqualityComparer<Book>
        {
            public bool Equals(Book x, Book y)
            {
                if (ReferenceEquals(x, y))
                    return true;
                if (ReferenceEquals(x, null) ||
                    ReferenceEquals(y, null))
                    return false;
                return x.Isbn == y.Isbn;
            }
            public int GetHashCode(Book obj)
                => obj.Isbn.GetHashCode();
        }
    }

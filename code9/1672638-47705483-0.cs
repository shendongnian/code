        private List<Book> _books;
        public IEnumerable<Book> Books
        {
            {
                 return _books;
            }
        }
        Public void AddBook(Book book)
        {
             //Validate 
            if(valid)
            {
                _books.Add(book);
            }
        }
        //Etc
    }

    class TextBookRenderer
    {
        public Type BookType => typeof(TextBook);
    
        public void RenderBook(Book b)
        {
            if(b is TextBoox textBook)
            {
                // output TextBook value
            }
    
            throw new ArgumentException("Passed book is not a TextBook", nameof(b));
        }
    }

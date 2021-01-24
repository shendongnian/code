    interface ISpecificBookRenderer 
    {
        Type BookType { get; }
    
        void RenderBook(Book b);
    }

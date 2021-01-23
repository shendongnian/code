    var books = _bookRepository.GetAll();
    
    if (!String.IsNullOrEmpty(title))
        books = books.Where(x => x.Title.Contains(title));
    
    if (!String.IsNullOrEmpty(authorName))
    {
        books = books.Where(x => x.LinkedAuthor.FirstName.Contains(authorName));
        books = books.Where(x => x.LinkedAuthor.LastName.Contains(authorName));
    }
     
